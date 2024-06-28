using Common;
using Enum;
using HttpServer;
using Protocol2;

namespace Service;

[ProtocolHandler]
public class ServiceCreateDashBoard : IService
{
    public ProtocolId ProtocolId { get; set; } = ProtocolId.CreateDashBoard;

    public async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request)
    {
        var req = (CreateDashBoardReq)request;
        var res = new CreateDashBoardRes();

        try
        {
            DashBoard dashBoard = new DashBoard()
            {
                Name = req.DashBoardName
            };
            
            if (await GameDB.GetDashBoardWithNameAsync(dashBoard.Name) != null)
                throw new MyException(Result.DashBoardNameAlreadyExists);
            
            await GameDB.SetDashBoardAsync(dashBoard);
            dashBoard = await GameDB.GetDashBoardWithNameAsync(dashBoard.Name);
            
            DashBoardManager dashBoardManager = new DashBoardManager()
            {
                Suid = req.Suid,
                DashBoardSeq = dashBoard.DashBoardSeq,
                Position = DashBoardPosition.Master,
                Enable = true
            };

            await GameDB.SetDashBoardManagerAsync(dashBoardManager);
        }
        catch (MyException e)
        {
            Console.WriteLine(e);
            res.Result = Result.CreateDashBoardFailed;
        }
        
        return res;
    }
}