using System;
using System.Threading.Channels;
using MessagePack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Protocol2;


namespace HttpProjectServer
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            Service.Service.Initialize();

            CreateHostBuilder(args).Build().Run();
            /*var requestData = new LoadDataReq
            {
                ProtocolId = ProtocolId.LoadData,
                UserId = 12345
            };
            
            ProtocolReq protocolReq = new ProtocolReq
            {
                Protocol = requestData
            };

            byte[] requestBytes = MessagePackSerializer.Serialize(protocolReq);
            ProtocolReq protocol = MessagePackSerializer.Deserialize<ProtocolReq>(requestBytes);
            LoadDataReq loadData = (LoadDataReq)protocol.Protocol;*/
        }

        
        /*Service.Service.Initialize();

            CreateHostBuilder(args).Build().Run();*/
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:8080"); // server url 내가세팅가능
                });
    }
}