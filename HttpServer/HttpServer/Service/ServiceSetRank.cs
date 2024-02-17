using Common;
using HttpServer;
using Protocol2;

namespace Service;

[ProtocolHandler]
public class ServiceSetRank : IService
{
    public ProtocolId ProtocolId { get; set; } = ProtocolId.SetRank;

    public async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request)
    {
        var req = (SetRankReq)request;
        var res = new SetRankRes();

        try
        {
            var winnerPlayer = await AccountDB.GetPlayerWithNicknameAsync(req.WinnerNickname);
            var loserPlayer = await AccountDB.GetPlayerWithNicknameAsync(req.LoserNickname);

            if (winnerPlayer == null || loserPlayer == null)
                return res;
            
            await RankManager.SetPlayerWinLoseAsync(winnerPlayer.Seq, loserPlayer.Seq);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return res;
    }
}