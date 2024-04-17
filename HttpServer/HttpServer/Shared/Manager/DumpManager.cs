using MySql.Data.MySqlClient;
using System.Text;
using Dapper;
using HttpServer.Shared.Common;

namespace HttpServer.Shared.Manager;

public class DumpManager
{
    public static async Task DumpAsync(string databaseName, string server, List<string> tableNames, bool compareRow = true, bool ExportProcedures = false)
    {
        string conn = (await DBConnectionInfo.GetConnectionInfoAsync(server, databaseName)).ConnectionString;
        
        using (MySqlConnection myCon = new MySqlConnection(conn))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                using (MySqlBackup mb = new MySqlBackup(cmd))
                {
                    try
                    {
                        StringBuilder exportedCombine = new StringBuilder();
                        await myCon.OpenAsync();
                        cmd.Connection = myCon;
                        foreach (var tableName in tableNames)
                        {
                            mb.ExportInfo.EnableComment = true;
                            mb.ExportInfo.ExportEvents = false;
                            mb.ExportInfo.ExportFunctions = false;
                            mb.ExportInfo.ExportProcedures = ExportProcedures;
                            mb.ExportInfo.ExportRows = compareRow;
                            mb.ExportInfo.ExportTriggers = false;
                            mb.ExportInfo.ExportViews = false;
                            mb.ExportInfo.AddDropTable = true;
                            mb.ExportInfo.ExportTableStructure = true;
                            mb.ExportInfo.TablesToBeExportedList = new List<string>() {tableName}; // <= 여기다가 뽑을 테이블명 정리하기
                            
                            string exported = mb.ExportToString();

                            exportedCombine.AppendLine("SET NAMES utf8mb4;");
                            exportedCombine.AppendLine("SET FOREIGN_KEY_CHECKS = 0;");
                            exportedCombine.AppendLine(exported);
                            exportedCombine.AppendLine("COMMIT;");
                            exportedCombine.AppendLine("SET FOREIGN_KEY_CHECKS = 1;");
                            exportedCombine.AppendLine();
                        }
                        
                        string savePath = $@"{DumpInfo.Instance.DumpFileSavePath}";
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                        await File.WriteAllTextAsync(savePath, exportedCombine.ToString(), Encoding.Default);

                        string[] connArray = conn.Split(new char[] {';'});
                        string dumpLogSaveConn = DumpInfo.Instance.LogSaveServerAddress;
                        
                        DateTime time = DateTime.Now;           
                        using (MySqlConnection connection = new MySqlConnection(dumpLogSaveConn))
                        {
                            try
                            {
                                await connection.OpenAsync();
                                foreach (var tableName in tableNames)
                                {
                                    await connection.ExecuteAsync(
                                        $"INSERT INTO tblDumpLog (`userName`, `connectionString`, `tableName`, `time`) VALUES ('{ServerInfo.Instance.MySqlUserName}', '{connArray[0]}', '{tableName}', '{time.ToString("yyyy-MM-dd HH:mm:ss")}')");
                                }
                            }
                            catch (MySqlException)
                            {
                                Console.WriteLine("Failed to connect to database. Check if table `dumpLog` exists.");
                            }
                        }
                        await myCon.CloseAsync();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }
    }
}