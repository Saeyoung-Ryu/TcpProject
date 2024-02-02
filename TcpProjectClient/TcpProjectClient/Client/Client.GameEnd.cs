using System.Diagnostics;
using Protocol;

namespace TcpProjectClient;

public partial class Client
{
    public async Task Process(GameEndA gameEndA)
    {
        if(gameEndA.IsWinner)
            Console.WriteLine("You Win!");
        else
            Console.WriteLine("You Lose!");

    }
}