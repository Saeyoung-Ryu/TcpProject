using System.Net.Sockets;
using Protocol;

namespace TcpProjectServer;

public partial class Remote
{
    private async Task ProcessAsync(SendAnswerQ sendAnswerQ)
    {
        Console.WriteLine("SendAnswerQ Called");
        Console.WriteLine($"{firstNumber}, {secondNumber}, {sendAnswerQ.Answer}");
        Console.WriteLine($"{sendAnswerQ.Stage}, {stage}");
        
        int clientNum = sendAnswerQ.ClientNum;
        
        if (firstNumber + secondNumber == sendAnswerQ.Answer)
        {
            if (stage == sendAnswerQ.Stage)
            {
                stage++;
                
                if (clientNum == 1)
                    client2Life--;
                else if (clientNum == 2)
                    client1Life--;
            }
            else
                return;
            
            SendToClient1(new SendAnswerA()
            {
                ClientNum = clientNum,
                SentAnswer = sendAnswerQ.Answer,
            });
            SendToClient2(new SendAnswerA()
            {
                ClientNum = clientNum,
                SentAnswer = sendAnswerQ.Answer,
            });

            if (client1Life == 0 || client2Life == 0)
            {
                await Task.Delay(2000);
                Process(new GameEndQ());
            }
            else
            {
                await Task.Delay(2000);
                Process(new SendQuestionQ());   
            }
        }
        else
        {
            if (stage == sendAnswerQ.Stage)
            {
                stage++;
            
                if (clientNum == 1)
                    client1Life--;
                else if (clientNum == 2)
                    client2Life--;
            }
            else
                return;
            
            SendToClient1(new SendAnswerA()
            {
                ClientNum = clientNum,
                SentAnswer = sendAnswerQ.Answer,
            });
            SendToClient2(new SendAnswerA()
            {
                ClientNum = clientNum,
                SentAnswer = sendAnswerQ.Answer,
            });
            
            if(client1Life == 0 || client2Life == 0)
                Process(new GameEndQ());
            else
            {
                await Task.Delay(2000);
                Process(new SendQuestionQ());   
            }
        }
    }
}