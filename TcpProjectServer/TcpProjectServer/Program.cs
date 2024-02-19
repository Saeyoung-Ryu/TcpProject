using System;
using Common;

namespace TcpProjectServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ServerInfoConfig.Refresh();
            ServerVariable.Refresh();

            Console.WriteLine("Tcp Server Has Started....");
            
            await TcpServerManager.StartServer(3360);
        }
    }
}