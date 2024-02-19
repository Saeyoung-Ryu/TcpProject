using Protocol;

namespace TcpProjectServer;

public partial class Remote
{
    public async Task ProcessAsync(AuthQ authQ)
    {
        Console.WriteLine("AuthQ Called");
        
        if (authQ.ClientNum == 1)
            client1Nickname = authQ.Nickname;
        if (authQ.ClientNum == 2)
            client2Nickname = authQ.Nickname;
    }
}