using Protocol;

namespace TcpProjectServer;

public partial class Remote
{
    public void Process(SendQuestionQ sendQuestionQ)
    {
        Console.WriteLine("SendQuestionQ Called");
        
        var twoNumbers = GameManager.GetTwoRandomNumbers();
        
        firstNumber = twoNumbers.Num1;
        secondNumber = twoNumbers.Num2;
        
        SendQuestionA sendQuestionA = new SendQuestionA()
        {
            Stage = stage,
            Client1Life = client1Life,
            Client2Life = client2Life,
            FirstNumber = twoNumbers.Num1,
            SecondNumber = twoNumbers.Num2
        };
        
        SendAll(sendQuestionA);
    }
}