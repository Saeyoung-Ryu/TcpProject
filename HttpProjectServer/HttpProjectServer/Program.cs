using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace YourNamespace
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            {
                
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    // webBuilder.UseUrls($"{MyProjectInfoConfig.Instance.ServerAddress}"); // this server url 내가세팅가능
                });
    }
}