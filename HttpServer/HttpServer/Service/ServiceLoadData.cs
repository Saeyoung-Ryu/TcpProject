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
            var player = await AccountDB.GetPlayerWithSuidAsync(req.Player.Suid);
            
            if (player == null)
                throw new MyException(Result.LoadDataFailed);

            res.PlayerAttendance = await AttendanceManager.GetPlayerAttendanceAsync(player);
        }
        catch (MyException e)
        {
            res.Result = e.Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            res.Result = Result.LoadDataFailed;
        }
        
        return res;
    }
}