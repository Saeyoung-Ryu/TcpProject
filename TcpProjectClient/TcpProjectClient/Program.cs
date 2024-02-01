using System;
using System.Globalization;

namespace TcpProjectClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            Client client = new Client("127.0.0.1", 3360);
            while (true)
            {
                
            }
        }
    }
}