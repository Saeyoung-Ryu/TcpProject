using Protocol;

namespace TcpProjectClient;

public partial class Client
{
    public void Process(SendAnswerA sendAnswerA, int firstNumber = 0, int secondNumber = 0)
    {
        // Console.WriteLine("SendAnswerA Called");
        canWrite = false;
        
        if (sendAnswerA.ClientNum == myClientNumber)
            return;

        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Other Client Has Answered : {sendAnswerA.SentAnswer}");
        Console.WriteLine("------------------------------------------");
    }
    
    /*
    static Task<string?> ReadInputAsync1()
    {
        Console.WriteLine("");
        Console.Write("Enter Answer: ");
        Console.WriteLine("");
        return Console.In.ReadLineAsync();
    }
    
    static async Task<string?> ReadInputAsync2()
    {
        Console.WriteLine("");
        Console.Write("Enter Answer: ");
        Console.WriteLine("");
        return await Console.In.ReadLineAsync();
    }*/
}