using Newtonsoft.Json;

namespace Common;

public class ServerInfoConfig
{
    private static ServerInfoConfig _instance;
    public static ServerInfoConfig Instance {
        get
        {
            if (_instance == null)
                _instance = new ServerInfoConfig();

            return _instance;
        }
    }
    
    public string ConnectionString { get; set; }
    public string ServerUrl { get; set; }
    
    public static void Refresh()
    {
        try
        {
            var configurationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ServerInfo.config");
            ServerInfoConfig serverInfoConfig = JsonConvert.DeserializeObject<ServerInfoConfig>(File.ReadAllText(configurationPath));

            _instance = serverInfoConfig;
            Console.WriteLine($"Config Refresh Success");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}