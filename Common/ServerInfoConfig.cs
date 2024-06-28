using Newtonsoft.Json;
using MyUtil;

namespace Common;

public class ServerInfoConfig : Singleton<ServerInfoConfig>
{
    public string ConnectionString { get; set; }
    public string ServerUrl { get; set; }
    public string RiotApiKey { get; set; }
    
    public static void Refresh()
    {
        try
        {
            var configurationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ServerInfo.config");
            ServerInfoConfig serverInfoConfig = JsonConvert.DeserializeObject<ServerInfoConfig>(File.ReadAllText(configurationPath));

            Instance = serverInfoConfig;
            MyLogger.WriteLineInfo($"Config Refresh Success");
        }
        catch (Exception e)
        {
            MyLogger.WriteLineError(e.Message.ToString());
            throw;
        }
    }
}