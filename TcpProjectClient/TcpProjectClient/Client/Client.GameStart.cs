using Protocol;

namespace TcpProjectClient;

public partial class Client
{
    public void Process(GameStartA gameStartA)
    {
        myClientNumber = gameStartA.ClientNum;
        var loadingTime = gameStartA.LoadingTime;

        Console.WriteLine($"You are Client {myClientNumber}");
        Console.WriteLine($"Game Starting in {loadingTime} seconds...");
        Console.WriteLine("Loading...");
    }
}