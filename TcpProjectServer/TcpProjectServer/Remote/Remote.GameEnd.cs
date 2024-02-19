using System.Net.Sockets;
using Common;
using Protocol;
using Protocol2;
using ProtocolId = Protocol.ProtocolId;

namespace TcpProjectServer;

public partial class Remote
{
    private async Task ProcessAsync(GameEndQ gameEndQ)
    {
        Console.WriteLine("GameEndQ Called");
        var setRankReq = new SetRankReq()
        {
            ProtocolId = Protocol2.ProtocolId.SetRank
        };
        
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

            setRankReq.WinnerNickname = client2Nickname;
            setRankReq.LoserNickname = client1Nickname;
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
            
            setRankReq.WinnerNickname = client1Nickname;
            setRankReq.LoserNickname = client2Nickname;
        }
            
        await HttpManager.SendHttpServerRequestAsync(setRankReq);
        
        client1.Close();
        client2.Close();
        TcpServerManager.remoteQueue.Enqueue(this);
        TcpServerManager.remoteSemaphore.Release();
    }
}