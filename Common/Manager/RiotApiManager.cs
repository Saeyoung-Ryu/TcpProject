using System.Reflection;
using MyUtil;
using RiotSharp;
using RiotSharp.Caching;
using RiotSharp.Misc;
using HttpServer.Cache;
using RiotSharpExtensions;

namespace Common;

[Refreshable]
public class RiotApiManager
{
    private static RiotApi api;

    public static void RefreshAsync()
    {
        try
        {
            var apiKey = ServerInfoConfig.Instance.RiotApiKey;
            
            api = RiotApi.GetInstance(apiKey, 20, 100);

            if (api.Status == null)
                throw new Exception();

            MyLogger.WriteLineInfo("RiotApiManager Refresh Success");
        }
        catch (Exception e)
        {
            MyLogger.WriteLineError("RiotApiManager Refresh Fail");
        }
    }

    public static async Task GetSummonerAsync(Region region, string gameName, string tagLine)
    {
        var account = await api.Account.GetAccountByRiotIdAsync(region, gameName, tagLine);
        string puuId = string.Empty;
        
        if (account != null)
            puuId = account.Puuid;
        
        var summoner = await api.Summoner.GetSummonerByPuuidAsync(Region.Kr, puuId);
        
        MyLogger.WriteLineInfo($"Summoner Name: {summoner.Name}");
        MyLogger.WriteLineInfo($"summoner Level: {summoner.Level}");
        
    }
}