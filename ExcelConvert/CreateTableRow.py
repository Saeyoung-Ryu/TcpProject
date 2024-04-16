import pandas as pd
import mysql.connector

def insert_data_from_excel(excel_file, table_name):
    # Read Excel file
    df = pd.read_excel(excel_file, sheet_name=table_name)

    # Connect to MySQL
    connection = mysql.connector.connect(
        host="localhost",
        user="root",
        password="Love^3536",
        database="ProjectDB"
    )
    cursor = connection.cursor()

    # Insert rows into MySQL table
    for index, row in df.iterrows():
        values = tuple(row)
        placeholders = ', '.join(['%s'] * len(row))
        insert_query = f"INSERT INTO {table_name} VALUES ({placeholders})"
        cursor.execute(insert_query, values)

    # Commit and close connection
    connection.commit()
    connection.close()

if __name__ == "__main__":
    insert_data_from_excel("ExcelData.xlsx", "tblAttendanceBasic")
    insert_data_from_excel("ExcelData.xlsx", "tblAttendanceReward")
    insert_data_from_excel("ExcelData.xlsx", "tblAttendanceEventSchedule")
