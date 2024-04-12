using Common;
using Enum;
using HttpServer;
using Protocol2;

namespace Service;

[ProtocolHandler]
public class ServiceGetMatchHistory : IService
{
    public ProtocolId ProtocolId { get; set; } = ProtocolId.GetMatchHistory;

    public async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request)
    {
        var req = (GetMatchHistoryReq)request;
        var res = new GetMatchHistoryRes();

        try
        {
            var player = await PlayerManager.GetPlayerWithNicknameAsync(req.NickName);

            if (player == null)
                return res;

            var playerMatchHistory = (await MatchHistoryManager.GetAsync(player)).MatchHistory;

            if (playerMatchHistory != null)
                res.MatchHistoryListDic = playerMatchHistory.FromData();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            res.Result = Result.GetMatchHistoryFailed;
        }
        
        return res;
    }
}