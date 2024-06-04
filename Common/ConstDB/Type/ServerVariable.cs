using System;
using System.Reflection;
using Common;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class ServerVariable
{
    public static string Life { get; private set; }
    public static string MinSumValue { get; private set; }
    public static string MaxSumValue { get; private set; }
    public static string RankServerURL { get; private set; }
    public static string RedisServerURL { get; private set; }

    public static async Task RefreshAsync()
    {
        await using (MySqlConnection connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
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

            MyLogger.WriteLineInfo("ServerVariable Refresh Success");
        }
    }
}