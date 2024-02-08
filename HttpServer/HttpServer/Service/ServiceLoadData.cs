using HttpServer;
using Microsoft.AspNetCore.Http;
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

        res.UserId = 88899;
        res.UserName = "TestUser123";
        Console.WriteLine("ServiceLoadData.ProcessAsync");

        return res;
    }
}