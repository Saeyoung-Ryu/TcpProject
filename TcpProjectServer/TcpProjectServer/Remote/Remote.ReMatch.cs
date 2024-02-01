using Protocol;

namespace TcpProjectServer;

public partial class Remote
{
    private void Process(ReMatchQ reMatchQ)
    {
        Console.WriteLine("ReMatchQ Called");
        Reset();
    }
}