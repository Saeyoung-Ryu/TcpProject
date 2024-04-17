using System.Data;
using System.Text.RegularExpressions;
using Dapper;
using HttpServer.Shared.Common;
using HttpServer.Shared.Enum;
using MySqlConnector;

namespace HttpServer.Shared.Manager;

public class CompareManager
{
    public static async Task<(List<TableInfo> TableInfo, Dictionary<string, DifferentType> ProcedureInfo)> CompareAsync(List<string> servers, string databaseName, List<TableInfo> tableInfos, bool checkRow, bool compareAllTables, bool compareSP)
    {
        Dictionary<string, DifferentType> procedureDifferentTypes = new Dictionary<string, DifferentType>();
        
        string server1 = servers[0];
        string server2 = servers[1];
        
        var connectionInfo1 = await DBConnectionInfo.GetConnectionInfoAsync(server1, databaseName);
        var connectionInfo2 = await DBConnectionInfo.GetConnectionInfoAsync(server2, databaseName);
        
        if (connectionInfo1 == null || connectionInfo2 == null)
            return (new List<TableInfo>(), procedureDifferentTypes);
        
        try
        {
            using (MySqlConnection connection1 = connectionInfo1.MySqlConnection ?? new MySqlConnection(connectionInfo1.ConnectionString))
            using (MySqlConnection connection2 = connectionInfo2.MySqlConnection ?? new MySqlConnection(connectionInfo2.ConnectionString))
            {
                if (connection1.State != ConnectionState.Open)
                    await connection1.OpenAsync();
                
                if (connection2.State != ConnectionState.Open)
                    await connection2.OpenAsync();

                if (compareAllTables)
                {
                    tableInfos.Clear();
                    
                    var conn1Tables = await GetAllTableNamesAsync(connection1);
                    var conn2Tables = await GetAllTableNamesAsync(connection2);
                    
                    var combinedList = conn1Tables.Union(conn2Tables).ToList().DistinctBy(e => e).ToList();
                    
                    foreach (var tableName in combinedList)
                    {
                        tableInfos.Add(new TableInfo() {TableName = tableName});
                    }
                }

                // check TABLE EXIST
                var tableNameWithNowExisting = await CompareTablesExistAsync(tableInfos, connection1, connection2);
                SetDifferentTablesAfterCompare(tableInfos, tableNameWithNowExisting, DifferentType.TableNotExist);

                // check TABLE COLUMN
                var tableNamesWithDifferentColumns = await CompareTableColumnsAsync(tableInfos.Where(e => e.DifferentType == DifferentType.None).ToList(), connection1, connection2);
                SetDifferentTablesAfterCompare(tableInfos, tableNamesWithDifferentColumns, DifferentType.ColumnDifferent);

                // check TABLE DATA. Const 테이블만 비교
                if (checkRow)
                {
                    var tableNamesWithDifferentData = await CompareTableDataAsync(
                        tableInfos.Where(e => e.DifferentType == DifferentType.None).ToList(), connection1,
                        connection2);
                    SetDifferentTablesAfterCompare(tableInfos, tableNamesWithDifferentData);
                }
                
                // check STORED PROCEDURE
                if (compareSP)
                {
                    procedureDifferentTypes = await CompareSpAsync(connection1, connection2);
                }

                DateTime time = DateTime.Now;
                string compareLogSaveConn = DumpInfo.Instance.LogSaveServerAddress;
                
                using (MySqlConnection connection = new MySqlConnection(compareLogSaveConn))
                {
                    try
                    {
                        await connection.OpenAsync();
                        foreach (var tableInfo in tableInfos)
                        {
                            int isDifferent = (tableInfo.DifferentType != DifferentType.None ? 1 : 0);
                            string[] connArray1 = server1.Split(new[] {';'});
                            string[] connArray2 = server2.Split(new[] {';'});
                            await connection.ExecuteAsync(
                                $"INSERT INTO tblCompareLog (`userName`, `connectionString1`, `connectionString2`, `tableName`, `isDifferent`, `time`)" +
                                $" VALUES ('{ServerInfo.Instance.MySqlUserName}', '{connArray1[0]}', '{connArray2[0]}', '{tableInfo.TableName}', '{isDifferent}', '{time.ToString("yyyy-MM-dd HH:mm:ss")}')");
                        }
                    }
                    catch (MySqlException)
                    {
                        Console.WriteLine("Failed to connect to database. Check if table `compareLog` exists.");
                    }
                }

                return (tableInfos, procedureDifferentTypes);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            if (connectionInfo1.MySqlConnection != null)
                await connectionInfo1.MySqlConnection.DisposeAsync();
            
            if (connectionInfo2.MySqlConnection != null)
                await connectionInfo2.MySqlConnection.DisposeAsync();
            
            if (connectionInfo1.ForwardedPortLocal != null)
                connectionInfo1.ForwardedPortLocal.Dispose();
            
            if (connectionInfo1.SshClient != null)
                connectionInfo1.SshClient.Dispose();
            
            if (connectionInfo2.ForwardedPortLocal != null)
                connectionInfo2.ForwardedPortLocal.Dispose();
            
            if (connectionInfo2.SshClient != null)
                connectionInfo2.SshClient.Dispose();
        }
    }
    
    private static async Task<Dictionary<string, DifferentType>> CompareSpAsync(MySqlConnection connection1, MySqlConnection connection2)
    {
        Dictionary<string, DifferentType> dictionary = new Dictionary<string, DifferentType>();
        
        var connection1ProcedureDic = await GetStoredProceduresDicAsync(connection1);
        var connection2ProcedureDic = await GetStoredProceduresDicAsync(connection2);
        
        var keyListInfos = GetKeyListInfos(connection1ProcedureDic.Keys.ToList(), connection2ProcedureDic.Keys.ToList());
        
        if (keyListInfos.Table1UniqueKeys.Count > 0)
        {
            foreach (var key in keyListInfos.Table1UniqueKeys)
            {
                dictionary.Add(key, DifferentType.ProcedureNotExistTable2);
            }
        }
        
        if (keyListInfos.Table2UniqueKeys.Count > 0)
        {
            foreach (var key in keyListInfos.Table2UniqueKeys)
            {
                dictionary.Add(key, DifferentType.ProcedureNotExistTable1);
            }
        }
        
        if (keyListInfos.DuplicatedKeys.Count > 0)
        {
            foreach (var key in keyListInfos.DuplicatedKeys)
            {
                if (connection1ProcedureDic[key].Definition != connection2ProcedureDic[key].Definition)
                {
                    dictionary.Add(key, DifferentType.ProcedureDifferent);
                }
            }
        }

        return dictionary;
    }
    
    private static async Task<Dictionary<string, ProcedureInfo>> GetStoredProceduresDicAsync(MySqlConnection connection)
    {
        Dictionary<string, ProcedureInfo> proceduresDic = new Dictionary<string, ProcedureInfo>();

        string query =
            $"SELECT ROUTINE_NAME, ROUTINE_DEFINITION FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE' AND ROUTINE_SCHEMA = '{connection.Database}';";

        MySqlCommand command = new MySqlCommand(query, connection);

        try
        {
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (await reader.ReadAsync())
                {
                    string procedureName = reader.GetString("ROUTINE_NAME");
                    string procedureDefinition = PreprocessProcedureDefinition(reader.GetString("ROUTINE_DEFINITION"));
                    
                    proceduresDic.Add(procedureName, new ProcedureInfo { Definition = procedureDefinition });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        return proceduresDic;
    }

    static string PreprocessProcedureDefinition(string definition)
    {
        // Remove all whitespace characters
        definition = Regex.Replace(definition, @"\s+", "");

        // Convert all letters to lowercase
        definition = definition.ToLower();

        return definition;
    }

    private static async Task<List<string>> GetAllTableNamesAsync(MySqlConnection connection)
    {
        List<string> tableNames = new List<string>();
        
        string query = "SELECT table_name FROM information_schema.tables WHERE table_schema = @databaseName AND table_type = 'BASE TABLE'";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@databaseName", connection.Database);

        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
        {
            while (reader.Read())
            {
                string tableName = reader.GetString(0);
                tableNames.Add(tableName);
            }
        }
        
        return tableNames;
    }
    
    private static void SetDifferentTablesAfterCompare(List<TableInfo> tableInfos, List<string> differentTables, DifferentType differentType = DifferentType.None)
    {
        foreach (var differentTable in differentTables)
        {
            foreach (var tableInfo in tableInfos)
            {
                if(tableInfo.TableName == differentTable)
                {
                    tableInfo.IsDifferent = true;
                    
                    if (differentType != DifferentType.None)
                        tableInfo.DifferentType = differentType;
                    
                    break;
                }
            }
        }
    }
    
    private static async Task<List<string>> CompareTablesExistAsync(List<TableInfo> tableInfos, MySqlConnection connection1, MySqlConnection connection2)
    {
        var tableNames = tableInfos.Select(e => e.TableName).ToList();

        var server1MissingTable = await TableExistsAsync(connection1, tableNames);
        var server2MissingTable = await TableExistsAsync(connection2, tableNames);

        var combinedList = server1MissingTable.Union(server2MissingTable).ToList();
                
        return combinedList;
    }
    
    private static async Task<List<string>> TableExistsAsync(MySqlConnection connection, List<string> tableNames)
    {
        List<string> missingTables = new List<string>();

        foreach (string tableName in tableNames)
        {
            string query = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{connection.Database}' AND table_name = '{tableName}'";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                object result = await command.ExecuteScalarAsync();
                if (result == null)
                    break;

                long count = (long)result;
                if (count == 0)
                {
                    missingTables.Add(tableName);
                }
            }
        }

        return missingTables;
    }

    private static async Task<List<string>> CompareTableColumnsAsync(List<TableInfo> tableInfos, MySqlConnection connection1, MySqlConnection connection2)
    {
        // var tableNames = tableInfos.Select(e => e.tableName).ToList();

        List<string> differentTables = new List<string>();

        foreach (var tableInfo in tableInfos)
        {
            List<Column> columnsServer1 = await GetTableColumnsAsync(connection1, tableInfo.TableName);
            List<Column> columnsServer2 = await GetTableColumnsAsync(connection2, tableInfo.TableName);

            var areColumnsEqual = AreColumnsEqual(columnsServer1, columnsServer2, tableInfo);
            
            if (!areColumnsEqual)
            {
                tableInfo.DifferentType = DifferentType.ColumnDifferent;
                differentTables.Add(tableInfo.TableName);
            }
        }
        
        return differentTables;
    }

    private static async Task<List<Column>> GetTableColumnsAsync(MySqlConnection connection, string tableName)
    {
        List<Column> columns = new List<Column>();

        string query = $"SELECT COLUMN_NAME, DATA_TYPE FROM information_schema.columns WHERE table_schema = '{connection.Database}' AND table_name = '{tableName}' ORDER BY ORDINAL_POSITION;";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                string columnName = reader.GetString(0);
                string dataType = reader.GetString(1);
                // int length = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);

                columns.Add(new Column(columnName, dataType));
            }
        }

        return columns;
    }

    private static bool AreColumnsEqual(List<Column> columns1, List<Column> columns2, TableInfo tableInfo)
    {
        /*
        List<Column> columns1Copy = columns1.Select(e => e).ToList();
        List<Column> columns2Copy = columns2.Select(e => e).ToList();
        */

        List<string> columns1StringList = columns1.Select(e => e.StringFormat).ToList();
        List<string> columns2StringList = columns2.Select(e => e.StringFormat).ToList();
        
        List<string> copyColumns1StringList = columns1StringList.Select(e => e).ToList();
        List<string> copyColumns2StringList = columns2StringList.Select(e => e).ToList();
        
        for (int i = 0; i < columns1.Count; i++)
        {
            for (int j = 0; j < columns2.Count; j++)
            {
                if (columns1[i].Name == columns2[j].Name & columns1[i].DataType == columns2[j].DataType)
                {
                    copyColumns1StringList[i] = string.Empty;
                    copyColumns2StringList[j] = string.Empty;
                    break;
                }
            }
        }
        
        var differentColumns1 = copyColumns1StringList.Where(e => e != string.Empty).ToList();
        var differentColumns2 = copyColumns2StringList.Where(e => e != string.Empty).ToList();

        if (differentColumns1.Count == 0 && differentColumns2.Count == 0)
        {
            // 테이블 컬럼들이 똑같으면 다음 row비교를 위해 컬럼들 넣어주기 (컬럼은 보여주기용으로 넣는다)
            tableInfo.Columns[0] = columns1StringList;
            tableInfo.Columns[1] = columns2StringList;
            
            return (true);
        }
        else
        {
            tableInfo.Columns[0] = differentColumns1;
            tableInfo.Columns[1] = differentColumns2;
            
            return (false);
        }
    }

    private static List<string> ForceFindPrimaryKeyColumnNames(TableInfo tableInfo, DataTable dataTable1, DataTable dataTable2)
    {
        try
        {
            int order = 1;
        
            HashSet<string> hashSet = new HashSet<string>();
        
            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                string primaryKey = string.Empty;
            
                for (int j = 0; j < order; j++)
                {
                    var value = dataTable1.Rows[i].ItemArray[j].ToString();
                
                    if (j == 0)
                        primaryKey += dataTable1.Rows[i].ItemArray[j].ToString();
                    else
                        primaryKey += $",{value}";

                    bool result = true;
                
                    if (j == order - 1)
                        result = hashSet.Add(primaryKey);

                    if (result == false) // Primary Key 불가능
                    {
                        hashSet.Clear();
                        order++;
                        i = -1;
                        break;
                    }
                }
            }

            List<string> primaryKeyColumnNames = new List<string>();
            for (int i = 0; i < order; i++)
            {
                primaryKeyColumnNames.Add(dataTable1.Columns[i].ColumnName);
            }
        
            return primaryKeyColumnNames;
        }
        catch (Exception)
        {
            return new List<string>();
        }
    }
    
    private static async Task<List<string>> CompareTableDataAsync(List<TableInfo> tableInfos, MySqlConnection connection1, MySqlConnection connection2)
    {
        // var tableNames = tableInfos.Select(e => e.tableName).ToList();

        List<string> differentTables = new List<string>();

        foreach (var tableInfo in tableInfos)
        {
            var tableDictionaryServer1 = GetTableDataDictionary(connection1, tableInfo.TableName, tableInfo);
            var tableDictionaryServer2 = GetTableDataDictionary(connection2, tableInfo.TableName, tableInfo);

            if (tableDictionaryServer1.Keys.Count > 0 && tableDictionaryServer2.Keys.Count > 0)
            {
                if (!AreTablesEqual(tableDictionaryServer1, tableDictionaryServer2, tableInfo))
                {
                    tableInfo.IsDifferent = true;
                    tableInfo.DifferentType = DifferentType.DataDifferentWithIndex;
                    differentTables.Add(tableInfo.TableName);
                }
            }
            else
            {
                DataTable tableServer1 = await GetTableDataAsync(connection1, tableInfo.TableName);
                DataTable tableServer2 = await GetTableDataAsync(connection2, tableInfo.TableName);
                
                var forceFindPrimaryKey = ForceFindPrimaryKeyColumnNames(tableInfo, tableServer1, tableServer2);

                if (forceFindPrimaryKey == null || forceFindPrimaryKey.Count == 0)
                {
                    // 강제로 primary Key 세팅 실패했을때
                    if (!AreTablesEqual(tableServer1, tableServer2, tableInfo))
                    {
                        tableInfo.IsDifferent = true;
                        tableInfo.DifferentType = DifferentType.DataDifferentWithoutIndex;
                        differentTables.Add(tableInfo.TableName);
                    }
                }
                else
                {
                    var forceTableDictionaryServer1 = GetTableDataDictionary(connection1, tableInfo.TableName, tableInfo, forceFindPrimaryKey);
                    var forceTableDictionaryServer2 = GetTableDataDictionary(connection2, tableInfo.TableName, tableInfo, forceFindPrimaryKey);
                    
                    if (!AreTablesEqual(forceTableDictionaryServer1, forceTableDictionaryServer2, tableInfo))
                    {
                        tableInfo.IsDifferent = true;
                        tableInfo.DifferentType = DifferentType.DataDifferentWithIndex;
                        differentTables.Add(tableInfo.TableName);
                    }
                }
            }
        }

        return differentTables;
    }

    private static async Task<DataTable> GetTableDataAsync(MySqlConnection connection, string tableName)
    {
        string query = $"SELECT * FROM {tableName}";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                await Task.Run(() => adapter.Fill(dataTable));
                return dataTable;
            }
        }
    }
    
    private static Dictionary<string, List<object>> GetTableDataDictionary(MySqlConnection connection, string tableName, TableInfo tableInfo, List<string> columnNames = null)
    {
        Dictionary<string, List<object>> rowsDictionary = new Dictionary<string, List<object>>();
        List<string> primaryKeyColumnNames = null;
        
        // Get the primary key column names
        if (columnNames == null)
            primaryKeyColumnNames = GetPrimaryKeyColumnNames(connection, tableName);
        else
            primaryKeyColumnNames = columnNames;    
        
        if (primaryKeyColumnNames == null || primaryKeyColumnNames.Count == 0)
            return new Dictionary<string, List<object>>();;
        
        tableInfo.PrimaryKeys = primaryKeyColumnNames;

        string query = $"SELECT * FROM {tableName}";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // string indexColumnValue = string.Empty;
                    List<string> indexColumnValues = new List<string>();

                    foreach (var columnName in primaryKeyColumnNames)
                    {
                        object columnValue = reader[columnName];
                        indexColumnValues.Add(columnValue.ToString());
                    }

                    List<object> rowData = new List<object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        // if (!primaryKeyColumnNames.Contains(columnName))
                        {
                            object columnValue = reader.GetValue(i);
                            rowData.Add(columnValue);
                        }
                    }

                    rowsDictionary.Add(string.Join(',', indexColumnValues), rowData);
                }
            }
        }

        return rowsDictionary;
    }
    
    private static List<string> GetPrimaryKeyColumnNames(MySqlConnection connection, string tableName)
    {
        List<string> primaryKeyColumnNames = new List<string>();

        string query = $@"
        SELECT COLUMN_NAME
        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
        WHERE TABLE_SCHEMA = '{connection.Database}'
          AND TABLE_NAME = '{tableName}'
          AND CONSTRAINT_NAME = 'PRIMARY'";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string columnName = reader["COLUMN_NAME"].ToString();
                    primaryKeyColumnNames.Add(columnName);
                }
            }
        }

        return primaryKeyColumnNames;
    }

    private static bool AreTablesEqual(Dictionary<string, List<object>> table1, Dictionary<string, List<object>> table2, TableInfo tableInfo)
    {
        bool isEqual = true;
        
        var keyListInfos = GetKeyListInfos(table1.Keys.ToList(), table2.Keys.ToList());

        if (keyListInfos.Table1UniqueKeys.Count > 0)
        {
            tableInfo.Table1UniqueKeyDictionary = FilterTable(table1, keyListInfos.Table1UniqueKeys);
            isEqual = false;
        }
        
        if (keyListInfos.Table2UniqueKeys.Count > 0)
        {
            tableInfo.Table2UniqueKeyDictionary = FilterTable(table2, keyListInfos.Table2UniqueKeys);
            isEqual = false;
        }

        if (keyListInfos.DuplicatedKeys.Count > 0)
        {
            // 각 데이터들 비교하기, 값이 다른게 있으면 tableInfo 에 넣어주기
            foreach (var duplicatedKey in keyListInfos.DuplicatedKeys)
            {
                var columnCount = tableInfo.Columns[0].Count;

                for (int i = 0; i < columnCount; i++)
                {
                    if (table1[duplicatedKey][i].ToString() != table2[duplicatedKey][i].ToString())
                    {
                        tableInfo.Table1ValueDiffDictionary.Add(duplicatedKey, table1[duplicatedKey]);
                        tableInfo.Table2ValueDiffDictionary.Add(duplicatedKey, table2[duplicatedKey]);
                        isEqual = false;
                        break;
                    }
                }
            }
        }

        return isEqual;
    }
    
    private static Dictionary<string, List<object>> FilterTable(Dictionary<string, List<object>> table, List<string> keys)
    {
        // Use LINQ to filter the dictionary based on keys in the list
        return table.Where(kvp => keys.Contains(kvp.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    private static (List<string> DuplicatedKeys, List<string> Table1UniqueKeys, List<string> Table2UniqueKeys) GetKeyListInfos(List<string> table1Keys, List<string> table2Keys)
    {
        HashSet<string> hashSet = new HashSet<string>();
        
        List<string> table1UniqueKeys = new List<string>();
        List<string> table2UniqueKeys = new List<string>();
        List<string> duplicateKeys = new List<string>();

        foreach (var key in table1Keys)
        {
            hashSet.Add(key);
        }

        foreach (var key in table2Keys)
        {
            var result = hashSet.Add(key);

            if (result == false)
            {
                hashSet.Remove(key);
                duplicateKeys.Add(key);
            }
            else
            {
                hashSet.Remove(key);
                table2UniqueKeys.Add(key);
            }
        }

        return (duplicateKeys, hashSet.ToList(), table2UniqueKeys);
    }
    
    private static bool AreTablesEqual(DataTable table1, DataTable table2, TableInfo tableInfo)
    {
        // tableInfo 안에 데이터가 다르면 isDifferent = true로 바꿔주기, DifferentType 세팅, 다른 데이터 row들 넣어주기
        int itemArrayCount = tableInfo.Columns[0].Count;

        for (int i = 0; i < table1.Rows.Count; i++)
        {
            bool foundSameRow = false;
            for (int j = 0; j < table2.Rows.Count; j++)
            {
                for (int k = 0; k < itemArrayCount; k++) // row가 같은지 다른지 체크
                {
                    if (!table1.Rows[i].ItemArray[k].Equals(table2.Rows[j].ItemArray[k]))
                    {
                        break;
                    }
                    
                    if (k == itemArrayCount - 1)
                        foundSameRow = true;
                }
                
                if(foundSameRow)
                    break;

                if (j == table2.Rows.Count - 1)
                {
                    if (foundSameRow == false)
                    {
                        var list = new List<object>();

                        foreach (var item in table1.Rows[i].ItemArray)
                        {
                            list.Add(item);
                        }
                        
                        tableInfo.Table1DifferentRows.Add(list);
                    }
                }
            }
        }
        
        for (int i = 0; i < table2.Rows.Count; i++)
        {
            bool foundSameRow = false;
            for (int j = 0; j < table1.Rows.Count; j++)
            {
                for (int k = 0; k < itemArrayCount; k++) // row가 같은지 다른지 체크
                {
                    if (!table2.Rows[i].ItemArray[k].Equals(table1.Rows[j].ItemArray[k]))
                    {
                        break;
                    }
                    
                    if (k == itemArrayCount - 1)
                        foundSameRow = true;
                }
                
                if(foundSameRow)
                    break;

                if (j == table1.Rows.Count - 1)
                {
                    if (foundSameRow == false)
                    {
                        var list = new List<object>();

                        foreach (var item in table2.Rows[i].ItemArray)
                        {
                            list.Add(item);
                        }
                        
                        tableInfo.Table2DifferentRows.Add(list);
                    }
                }
            }
        }
        
        return tableInfo.Table1DifferentRows.Count == 0 && tableInfo.Table2DifferentRows.Count == 0;
    }
    
}