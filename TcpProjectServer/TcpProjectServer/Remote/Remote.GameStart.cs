using Protocol;

namespace TcpProjectServer;

public partial class Remote
{
    public async Task ProcessAsync(GameStartQ gameStartQ)
    {
        Console.WriteLine("GameStartQ Called");
        
        GameStartA gameStartA = new GameStartA()
        {
            LoadingTime = 3
        };
        
        gameStartA.ClientNum = 1;
        SendToClient1(gameStartA);
        gameStartA.ClientNum = 2;
        SendToClient2(gameStartA);

        await Task.Delay(gameStartA.LoadingTime * 1000);

        Process(new SendQuestionQ());
    }
}