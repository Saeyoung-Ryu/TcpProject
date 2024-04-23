import os
import mysql.connector
from mysql.connector import Error

# Function to generate C# class script for a given table
def generate_csharp_class(table_name, columns):
    # Capitalize the first letter of the table name
    class_name = table_name[0].upper() + table_name[1:]

    class_script = f"""
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class {class_name}
{{"""
    
    # Generate property declarations
    for column in columns:
        field_name = column[0][0].upper() + column[0][1:]  # Uppercase the first letter of the field name
        field_type = "string" if column[1] == "varchar(255)" else column[1]  # Convert varchar(255) to string type
        class_script += f"""
    public {field_type} {field_name} {{ get; private set; }}"""

    # Generate dictionary and list declarations
    class_script += f"""
    
    public static Dictionary<int, {class_name}> Dictionary = new Dictionary<int, {class_name}>();
    public static List<{class_name}> ListAll = new List<{class_name}>();
    
    public static async Task RefreshAsync()
    {{
        try
        {{
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {{
                string sql = "select * from {table_name}";

                var list = await connection.QueryAsync<{class_name}>(sql);

                foreach (var item in list)
                {{
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }}
            }}
            
            MyLogger.WriteLineInfo("{class_name} Refresh Success");
        }}
        catch (Exception)
        {{
            MyLogger.WriteLineError("{class_name} Refresh Error");
        }}
        
    }}
}}"""

    return class_script

    class_script = f"""
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class {table_name}
{{"""
    
    # Generate property declarations
    for column in columns:
        field_name = column[0][0].upper() + column[0][1:]  # Uppercase the first letter of the field name
        field_type = "string" if column[1] == "varchar(255)" else column[1]  # Convert varchar(255) to string type
        class_script += f"""
    public {field_type} {field_name} {{ get; private set; }}"""

    # Generate dictionary and list declarations
    class_script += f"""
    
    public static Dictionary<int, {table_name}> Dictionary = new Dictionary<int, {table_name}>();
    public static List<{table_name}> ListAll = new List<{table_name}>();
    
    public static async Task RefreshAsync()
    {{
        try
        {{
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {{
                Dictionary.Clear();
                ListAll.Clear();
                
                string sql = "select * from {table_name}";

                var list = await connection.QueryAsync<{table_name}>(sql);

                foreach (var item in list)
                {{
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }}
            }}
            
            MyLogger.WriteLineInfo("{table_name} Refresh Success");
        }}
        catch (Exception)
        {{
            MyLogger.WriteLineError("{table_name} Refresh Error");
        }}
        
    }}
}}"""

    return class_script

    class_script = f"""
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class {table_name}
{{"""
    
    # Generate property declarations
    for column in columns:
        field_name = column[0].upper()  # Convert field name to uppercase
        field_type = "string" if column[1] == "varchar(255)" else column[1]  # Convert varchar(255) to string type
        class_script += f"""
    public {field_type} {field_name} {{ get; private set; }}"""

    # Generate dictionary and list declarations
    class_script += f"""
    
    public static Dictionary<int, {table_name}> Dictionary = new Dictionary<int, {table_name}>();
    public static List<{table_name}> ListAll = new List<{table_name}>();
    
    public static async Task RefreshAsync()
    {{
        try
        {{
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {{
                string sql = "select * from {table_name}";

                var list = await connection.QueryAsync<{table_name}>(sql);

                foreach (var item in list)
                {{
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }}
            }}
            
            MyLogger.WriteLineInfo("{table_name} Refresh Success");
        }}
        catch (Exception)
        {{
            MyLogger.WriteLineError("{table_name} Refresh Error");
        }}
        
    }}
}}"""

    return class_script

    class_script = f"""
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class {table_name}
{{"""
    
    # Generate property declarations
    for column in columns:
        class_script += f"""
    public {column[1]} {column[0]} {{ get; private set; }}"""

    # Generate dictionary and list declarations
    class_script += f"""
    
    public static Dictionary<int, {table_name}> Dictionary = new Dictionary<int, {table_name}>();
    public static List<{table_name}> ListAll = new List<{table_name}>();
    
    public static async Task RefreshAsync()
    {{
        try
        {{
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {{
                string sql = "select * from {table_name}";

                var list = await connection.QueryAsync<{table_name}>(sql);

                foreach (var item in list)
                {{
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }}
            }}
            
            MyLogger.WriteLineInfo("{table_name} Refresh Success");
        }}
        catch (Exception)
        {{
            MyLogger.WriteLineError("{table_name} Refresh Error");
        }}
        
    }}
}}"""

    return class_script

# Function to retrieve all table names in the database
def get_all_table_names():
    try:
        connection = mysql.connector.connect(host='localhost',
                                             database='ProjectDB',
                                             user='root',
                                             password='Love^3536')
        if connection.is_connected():
            cursor = connection.cursor()
            cursor.execute("SHOW TABLES")
            tables = cursor.fetchall()
            return [table[0] for table in tables]
    except Error as e:
        print("Error reading data from MySQL", e)
    finally:
        if (connection.is_connected()):
            cursor.close()
            connection.close()

# Function to retrieve schema information for a given table
def get_table_schema(table_name):
    try:
        connection = mysql.connector.connect(host='localhost',
                                             database='ProjectDB',
                                             user='root',
                                             password='Love^3536')
        if connection.is_connected():
            cursor = connection.cursor()
            cursor.execute(f"DESCRIBE {table_name}")
            columns = cursor.fetchall()
            return columns
    except Error as e:
        print("Error reading data from MySQL table", e)
    finally:
        if (connection.is_connected()):
            cursor.close()
            connection.close()

# Function to save the generated class script to a file
def save_class_script(class_script, table_name, path):
    file_path = os.path.join(path, f"{table_name}.cs")
    with open(file_path, "w") as file:
        file.write(class_script)
    print(f"Class script for table '{table_name}' saved to '{file_path}'")

# Main function
def main():
    table_names = get_all_table_names()
    output_path = "/Users/saeyoungryu/Project/TcpProject/ExcelConvert/ClassConverter"  # Specify the output path here
    
    for table_name in table_names:
        columns = get_table_schema(table_name)
        if columns:
            class_script = generate_csharp_class(table_name, columns)
            save_class_script(class_script, table_name, output_path)

if __name__ == "__main__":
    main()
