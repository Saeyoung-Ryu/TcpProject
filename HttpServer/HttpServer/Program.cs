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
            Service.Service.Initialize();

            // var blazorHost = CreateHostBuilder(args).Build();
            // blazorHost.RunAsync();
            
            var httpServerHost = CreateHttpServerHostBuilder(args).Build();
            httpServerHost.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<BlazorStartup>();
                    webBuilder.UseUrls("http://localhost:9090");
                });

        public static IHostBuilder CreateHttpServerHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:8080");
                });
    }
}