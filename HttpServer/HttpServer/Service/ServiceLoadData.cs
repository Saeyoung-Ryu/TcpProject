using Common;
using Enum;
using HttpServer;
using Protocol2;

namespace Service;

[ProtocolHandler]
public class ServiceLoadData : IService
{
    public ProtocolId ProtocolId { get; set; } = ProtocolId.LoadData;

    public async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request)
    {
        var req = (LoadDataReq)request;
        var res = new LoadDataRes();

        try
        {
            var playerInfo = await PlayerManager.GetPlayerWithNicknameAsync(req.Email, true, true);

            if (playerInfo == null)
                return res;
            
            res.NickName = playerInfo.Nickname;
            res.CreateTime = playerInfo.CreateTime;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            res.Result = Result.LoadDataFailed;
        }
        
        return res;
    }
}