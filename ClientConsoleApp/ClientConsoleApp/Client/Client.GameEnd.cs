using System.Diagnostics;
using Protocol;

namespace ClientConsoleApp;

public partial class Client
{
    public async Task ProcessAsync(GameEndA gameEndA)
    {
        if(gameEndA.IsWinner)
            Console.WriteLine("You Win!");
        else
            Console.WriteLine("You Lose!");

        gameEnd = true;
    }
}