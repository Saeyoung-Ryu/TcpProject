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
            LoadDataRes loadDataRes = new LoadDataRes();
            var player = await AccountDB.GetPlayerAsync(req.NickName);

            if (player == null)
            {
                await AccountDB.SetPlayerAsync(req.NickName);
                loadDataRes.NickName = req.NickName;
                loadDataRes.CreateTime = DateTime.UtcNow;
            }
            else
            {
                loadDataRes.NickName = player.Nickname;
                loadDataRes.CreateTime = player.CreateTime;
            }

            res = loadDataRes;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return res;
    }
}