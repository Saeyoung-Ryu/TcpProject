using System;
using System.Reflection;
using Common;
using MySqlConnector;

class ServerVariable
{
    public static string Life { get; set; }
    public static string MinSumValue { get; set; }
    public static string MaxSumValue { get; set; }
    public static string RankServerURL { get; set; }

    public static void Refresh()
    {
        using (MySqlConnection connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
        {
            connection.Open();

            string query = "SELECT Name, Value FROM tblServerVariable";

            MySqlCommand command = new MySqlCommand(query, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string name = reader.GetString("Name");
                    string value = reader.GetString("Value");

                    PropertyInfo property = typeof(ServerVariable).GetProperty(name);
                    if (property != null && property.CanWrite)
                    {
                        property.SetValue(null, value);
                    }
                }
            }

            Console.WriteLine("ServerVariable Refresh Success");
        }
    }
}