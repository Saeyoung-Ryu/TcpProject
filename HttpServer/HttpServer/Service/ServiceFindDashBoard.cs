using Common;
using Enum;
using HttpServer;
using Protocol2;

namespace Service;

[ProtocolHandler]
public class ServiceFindDashBoard : IService
{
    public ProtocolId ProtocolId { get; set; } = ProtocolId.FindDashBoard;

    public async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request)
    {
        var req = (FindDashBoardReq)request;
        var res = new FindDashBoardRes();

        try
        {
            
        }
        catch (MyException e)
        {
            Console.WriteLine(e);
            res.Result = Result.DashBoardNotFound;
        }
        
        return res;
    }
}