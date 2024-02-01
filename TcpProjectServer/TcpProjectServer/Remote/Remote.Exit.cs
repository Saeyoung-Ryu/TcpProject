using Protocol;

namespace TcpProjectServer;

public partial class Remote
{
    private void Process(ExitQ exitQ)
    {
        Console.WriteLine("ExitQ Called");
        
        TcpServerManager.remoteQueue.Enqueue(this);
    }
}