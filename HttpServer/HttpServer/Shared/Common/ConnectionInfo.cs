using System.Text;
using MySqlConnector;
using Renci.SshNet;

namespace HttpServer.Shared.Common;

public class DBConnectionInfo
{
    public string ConnectionString { get; set; }
    public SshClient SshClient { get; set; }
    public ForwardedPortLocal ForwardedPortLocal { get; set; }
    public MySqlConnection MySqlConnection { get; set; }
    
    public static async Task<DBConnectionInfo> GetConnectionInfoAsync(string server, string databaseName)
    {
        string connectionString = string.Empty;
        DBConnectionInfo connectionInfo = null;
        SshClient sshClient = null;
        ForwardedPortLocal forwardedPortLocal = null;

        try
        {
            StringBuilder connectionStringBuilder = new StringBuilder();

            connectionStringBuilder.Append($"server={server};");

            if (ServerInfo.Instance.MySqlPort != string.Empty)
                connectionStringBuilder.Append($"Port={ServerInfo.Instance.MySqlPort};");
            if (ServerInfo.Instance.MySqlUserName != string.Empty)
                connectionStringBuilder.Append($"Uid={ServerInfo.Instance.MySqlUserName};");
            if (ServerInfo.Instance.MySqlPassword != string.Empty)
                connectionStringBuilder.Append($"Pwd={ServerInfo.Instance.MySqlPassword};");

            connectionStringBuilder.Append($"database={databaseName}");

            connectionString = connectionStringBuilder.ToString();

            MySqlConnection connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            connectionInfo = new DBConnectionInfo()
            {
                ConnectionString = connectionString,
                MySqlConnection = connection
            };

            return connectionInfo;
        }
        catch (MySqlException)
        {
            try
            {
                sshClient = new SshClient(ServerInfo.Instance.SshHost,
                    int.Parse(ServerInfo.Instance.SshPort),
                    ServerInfo.Instance.SshUserName, ServerInfo.PrivateKeyFileArray);

                sshClient.Connect();

                if (sshClient.IsConnected)
                {
                    forwardedPortLocal = new ForwardedPortLocal("localhost", 0, server,
                        (uint) int.Parse(ServerInfo.Instance.MySqlPort));
                    sshClient.AddForwardedPort(forwardedPortLocal);
                    forwardedPortLocal.Start(); // 닫아주기
                    connectionString =
                        $"Server=localhost;Port={forwardedPortLocal.BoundPort};Database={databaseName};Uid={ServerInfo.Instance.MySqlUserName};Pwd={ServerInfo.Instance.MySqlPassword};";
                }
                else
                    throw new Exception("SSH Connection Failed");
                
                MySqlConnection connection = new MySqlConnection(connectionString);
                await connection.OpenAsync();

                connectionInfo = new DBConnectionInfo()
                {
                    ConnectionString = connectionString,
                    SshClient = sshClient,
                    ForwardedPortLocal = forwardedPortLocal,
                    MySqlConnection = connection
                };

                return connectionInfo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                if (connectionInfo != null)
                {
                    connectionInfo.MySqlConnection?.DisposeAsync();
                    connectionInfo.ForwardedPortLocal?.Dispose();
                    connectionInfo.SshClient?.Dispose();
                }

                return null;
            }
        }
    }
}