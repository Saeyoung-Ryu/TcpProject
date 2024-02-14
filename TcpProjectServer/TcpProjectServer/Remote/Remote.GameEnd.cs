using System.Net.Sockets;
using Protocol;

namespace TcpProjectServer;

public partial class Remote
{
    private async Task ProcessAsync(GameEndQ gameEndQ)
    {
        Console.WriteLine("GameEndQ Called");
        
        if (client1Life == 0)
        {
            await SendToClient1(new GameEndA()
            {
                IsWinner = false
            });
            await SendToClient2(new GameEndA()
            {
                IsWinner = true
            });
        }
        else if (client2Life == 0)
        {
            await SendToClient1(new GameEndA()
            {
                IsWinner = true
            });
            await SendToClient2(new GameEndA()
            {
                IsWinner = false
            });
        }
        
        client1.Close();
        client2.Close();
        TcpServerManager.remoteQueue.Enqueue(this);
        TcpServerManager.remoteSemaphore.Release();
    }
}