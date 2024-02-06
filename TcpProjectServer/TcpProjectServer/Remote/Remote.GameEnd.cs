using System.Net.Sockets;
using Protocol;

namespace TcpProjectServer;

public partial class Remote
{
    private void Process(GameEndQ gameEndQ)
    {
        Console.WriteLine("GameEndQ Called");
        
        if (client1Life == 0)
        {
            SendToClient1(new GameEndA()
            {
                IsWinner = false
            });
            SendToClient2(new GameEndA()
            {
                IsWinner = true
            });
        }
        else if (client2Life == 0)
        {
            SendToClient1(new GameEndA()
            {
                IsWinner = true
            });
            SendToClient2(new GameEndA()
            {
                IsWinner = false
            });
        }
        
        client1.Close();
        client2.Close();
        TcpServerManager.remoteQueue.Enqueue(this);
    }
}