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
        Console.ForegroundColor = ConsoleColor.Blue; // Set color to red
        Console.WriteLine($"Other Client Has Answered : {sendAnswerA.SentAnswer}");
        Console.ResetColor();
        Console.WriteLine("------------------------------------------");
    }
}