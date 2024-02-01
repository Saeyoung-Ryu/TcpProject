using Protocol;

namespace TcpProjectServer;

public partial class Remote
{
    private void Process(DisconnectedQ disconnectedQ)
    {
        Console.WriteLine("DisconnectedQ called");
        SendAll(disconnectedQ);
    }
}