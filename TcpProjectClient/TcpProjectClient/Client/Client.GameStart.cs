using Protocol;

namespace TcpProjectClient;

public partial class Client
{
    public async Task Process(GameStartA gameStartA)
    {
        myClientNumber = gameStartA.ClientNum;
        var loadingTime = gameStartA.LoadingTime;

        Console.WriteLine($"You are Client {myClientNumber}");
        int count = loadingTime;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Game Starting in {loadingTime--} seconds...");
            await Task.Delay(1000);
        }
    }
}