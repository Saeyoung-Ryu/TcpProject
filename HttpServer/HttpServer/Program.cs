using Common;

namespace HttpServer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ServerInfoConfig.Refresh();
            ServerVariable.Refresh();
            Service.Service.Initialize();
            await LoginManager.RefreshSeqAsync();

            await RankManager.RefreshRankAsync();

            Console.WriteLine("Http Server Has Started....");
            
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