using System;

namespace TcpProjectServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {


            await TcpServerManager.Start(3360);
        }
    }
}