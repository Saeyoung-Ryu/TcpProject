import pandas as pd
import mysql.connector

def create_table_schema(excel_file, table_name, primary_keys=None):
    # Read the first sheet of the Excel file
    df = pd.read_excel(excel_file, sheet_name=table_name)

    # Get column names and data types
    column_info = []
    for column_name, dtype in zip(df.columns, df.dtypes):
        if dtype == 'int64':
            data_type = 'INT'
        elif dtype == 'float64':
            data_type = 'FLOAT'
        elif pd.api.types.is_datetime64_any_dtype(dtype):
            data_type = 'DATETIME'
        elif dtype == 'object':
            data_type = 'VARCHAR(255)'
        else:
            data_type = 'VARCHAR(255)'
        column_info.append(f"{column_name} {data_type}")
        
    if primary_keys:
        primary_keys_str = ", ".join(primary_keys)
        column_info.append(f"PRIMARY KEY ({primary_keys_str})")

    # Connect to MySQL
    connection = mysql.connector.connect(
        host="localhost",
        user="root",
        password="Love^3536",
        database="ProjectDB"
    )
    cursor = connection.cursor()

    # Create table with dynamic column names and data types
    create_table_query = f"CREATE TABLE {table_name} ({', '.join(column_info)})"
    cursor.execute(create_table_query)

    # Commit and close connection
    connection.commit()
    connection.close()

if __name__ == "__main__":
    create_table_schema("ExcelData.xlsx", "tblAttendanceBasic", ["basicId", "days"])
    create_table_schema("ExcelData.xlsx", "tblAttendanceReward", ["attendanceRewardId"])
    create_table_schema("ExcelData.xlsx", "tblAttendanceEventSchedule")
