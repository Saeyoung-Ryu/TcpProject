﻿using System;
using Common;

namespace TcpProjectServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            
            await TcpServerManager.StartServer(3360);
        }
    }
}