using Protocol;

namespace TcpProjectClient;

public partial class Client
{
    public async Task ProcessAsync(SendQuestionA sendQuestionA)
    {
        // Console.WriteLine("SendQuestionA Called");

        Console.WriteLine("");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"---------------<<Stage {sendQuestionA.Stage}>>---------------");
        Console.WriteLine($"(Client1 Life: {sendQuestionA.Client1Life} | Client2 Life: {sendQuestionA.Client2Life})");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"What is {sendQuestionA.FirstNumber} + {sendQuestionA.SecondNumber}?");
        Console.WriteLine("Write your answer and press Enter...");

        stage = sendQuestionA.Stage;
        
        canWrite = true;
        // Thread answerThread1 = new Thread(() => Task.Run(() => ProcessSendAsync()));
        // answerThread1.Start();

    }
}