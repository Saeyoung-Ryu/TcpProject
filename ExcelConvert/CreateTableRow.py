import pandas as pd
import mysql.connector
import socket
from datetime import datetime

table_names = []

def getIPAddress():
    try:
        # Create a socket object
        s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        # Connect to a remote server on port 80 (HTTP)
        s.connect(("8.8.8.8", 80))
        # Get the socket's own IP address
        ip_address = s.getsockname()[0]
        # Close the socket
        s.close()
        return ip_address
    except Exception as e:
        return str(e)  

def importLog(tables, host = ""):
    try:
        log_db = mysql.connector.connect(
            host="localhost",
            port=3306,
            user="root",
            password="",
            database="ProjectDB"
        )
        cursor = log_db.cursor()
        
        # Define the insert query and current time
        insert_query = """
            INSERT INTO tblImportToMySql (ipAddress, tableName, host, time)
            VALUES (%s, %s, %s, %s)
        """
        current_time = datetime.now()
        ipAddress = getIPAddress()
        table_names = ", ".join(tables)
        
        # Try to execute the insert query
        try:
            cursor.execute(insert_query, (ipAddress, table_names, host, current_time))
        except mysql.connector.Error as err:
            if err.errno == 1146:  # Error code for table does not exist
                # Create the table
                create_table_query = """
                    CREATE TABLE tblImportToMySql (
                        seq INT AUTO_INCREMENT PRIMARY KEY,
                        ipAddress VARCHAR(45),
                        tableName TEXT,
                        host VARCHAR(45),
                        time DATETIME
                    )
                """
                cursor.execute(create_table_query)
                # Retry the insert query
                cursor.execute(insert_query, (ipAddress, table_names, host, current_time))
            else:
                raise
        
        log_db.commit()
        cursor.close()
        log_db.close()
    except mysql.connector.Error as err:
        print(f"Error: {err}")

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

    try:
        # Begin transaction
        connection.start_transaction()

        # Empty the table
        cursor.execute(f"DELETE FROM {table_name}")

        # Insert rows into MySQL table
        for index, row in df.iterrows():
            values = tuple(row)
            placeholders = ', '.join(['%s'] * len(row))
            insert_query = f"INSERT INTO {table_name} VALUES ({placeholders})"
            cursor.execute(insert_query, values)

        # Commit transaction
        connection.commit()
        table_names.append(table_name)
    except Exception as e:
        # Rollback transaction if any error occurs
        print(f"An error occurred: {e}")
        connection.rollback()
    finally:
        # Close connection
        connection.close()

if __name__ == "__main__":
    insert_data_from_excel("ExcelData.xlsx", "tblAttendanceBasic")
    insert_data_from_excel("ExcelData.xlsx", "tblAttendanceReward")
    insert_data_from_excel("ExcelData.xlsx", "tblAttendanceEventSchedule")
    
    importLog(table_names)
