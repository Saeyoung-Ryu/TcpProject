using Common;
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
            var playerInfo = await AccountDB.GetPlayerWithNicknameAsync(req.NickName);

            if (playerInfo == null)
            {
                res.NickName = req.NickName;
                res.CreateTime = DateTime.UtcNow;
            }
            else
            {
                res.NickName = playerInfo.Nickname;
                res.CreateTime = playerInfo.CreateTime;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return res;
    }
}