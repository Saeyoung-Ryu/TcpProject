using Protocol;

namespace TcpProjectClient;

public partial class Client
{
    public void Process(ReMatchA reMatchA)
    {
        Console.WriteLine("Do you want to rematch? (y/n)");
        
        var input = Console.ReadLine();
        if (input == "y")
        {
            Send(new ReMatchQ()
            {
                ClientNum = myClientNumber,
                DoReMatch = true,
            });
        }
        else if (input == "n")
        {
            Send(new ExitQ()
            {
                ClientNum = myClientNumber
            });
        }
    }
}