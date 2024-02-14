using System.Diagnostics;
using Protocol;

namespace TcpProjectClient;

public partial class Client
{
    public async Task ProcessAsync(GameEndA gameEndA)
    {
        Console.WriteLine("GameEndA Called");
        
        if(gameEndA.IsWinner)
            Console.WriteLine("You Win!");
        else
            Console.WriteLine("You Lose!");
    }
}