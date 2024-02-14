using Protocol;

namespace ClientConsoleApp;

public partial class Client
{
    public async Task ProcessAsync(SendQuestionA sendQuestionA)
    {
        // Console.WriteLine("SendQuestionA Called");

        Console.WriteLine("");
        Console.WriteLine("------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green; // Set color to green
        Console.WriteLine($"---------------<<Round {sendQuestionA.Round}>>---------------");
        Console.ResetColor(); // Reset color to default
        Console.ForegroundColor = ConsoleColor.Red; // Set color to red
        Console.WriteLine($"(Client1 Life: {sendQuestionA.Client1Life} | Client2 Life: {sendQuestionA.Client2Life})");
        Console.ResetColor(); // Reset color to default
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"What is {sendQuestionA.FirstNumber} + {sendQuestionA.SecondNumber}?");
        Console.WriteLine("Write your answer and press Enter...");


        stage = sendQuestionA.Round;
        
        canWrite = true;
        // Thread answerThread1 = new Thread(() => Task.Run(() => ProcessSendAsync()));
        // answerThread1.Start();

    }
}