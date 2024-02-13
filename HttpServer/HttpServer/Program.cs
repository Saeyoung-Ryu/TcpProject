using Common;

namespace HttpServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServerInfoConfig.Refresh();
            ServerVariable.Refresh();
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