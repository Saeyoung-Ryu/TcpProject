using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using HttpServer.Data;

namespace HttpServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServerInfoConfig.Refresh();
            Service.Service.Initialize();
            
            CreateHttpServerHostBuilder(args).Build().Run();
        }


        private static IHostBuilder CreateHttpServerHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls(ServerInfoConfig.Instance.ServerUrl);
                });
    }
}