using Common;
using Enum;
using HttpServer;
using Protocol2;

namespace Service;

[ProtocolHandler]
public class ServiceGetRank : IService
{
    public ProtocolId ProtocolId { get; set; } = ProtocolId.GetRank;

    public async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request)
    {
        var req = (GetRankReq)request;
        var res = new GetRankRes();

        try
        {
            var player = await PlayerManager.GetPlayerWithNicknameAsync(req.NickName);

            if (player == null)
                return res;

            (var PlayerRank, int Ranking) = RankManager.GetRank(player.Seq);

            res.WinCount = PlayerRank.WinCount;
            res.LoseCount = PlayerRank.LoseCount;
            res.Point = PlayerRank.Point;
            res.Ranking = Ranking;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            res.Result = Result.GetRankFailed;
        }
        
        return res;
    }
}