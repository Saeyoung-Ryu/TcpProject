using Common;
using MyUtil;

namespace HttpServer.Shared.Common;

[Refreshable]
public class DumpInfo
{
    public static DumpInfo Instance { get; private set; }
    public string DumpFileSavePath { get; set; }
    public string LogSaveServerAddress { get; set; }
    
    public static async Task RefreshAsync()
    {
        var configurationPath = "Shared/DumpInfo.config";
        string jsonString = await File.ReadAllTextAsync(configurationPath);
        var dumpInfo = System.Text.Json.JsonSerializer.Deserialize<DumpInfo>(jsonString);

        MyLogger.WriteLineInfo($"DumpInfo Refreshed");

        Instance = dumpInfo;
    }
}