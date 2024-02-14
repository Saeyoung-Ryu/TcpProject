using System.Net.Sockets;
using Protocol;

namespace TcpProjectServer;

public partial class Remote
{
    public async Task ProcessAsync(SendAnswerQ sendAnswerQ)
    {
        Console.WriteLine("SendAnswerQ Called");
        
        int clientNum = sendAnswerQ.ClientNum;
        
        if (firstNumber + secondNumber == sendAnswerQ.Answer)
        {
            await roundSemaphore.WaitAsync();
            
            if (round == sendAnswerQ.Round)
            {
                round++;
                roundSemaphore.Release(1);
                
                if (clientNum == 1)
                    client2Life--;
                else if (clientNum == 2)
                    client1Life--;
            }
            else
            {
                roundSemaphore.Release(1);
                return;
            }
            
            await SendToClient1(new SendAnswerA()
            {
                ClientNum = clientNum,
                SentAnswer = sendAnswerQ.Answer,
            });
            await SendToClient2(new SendAnswerA()
            {
                ClientNum = clientNum,
                SentAnswer = sendAnswerQ.Answer,
            });

            if (client1Life == 0 || client2Life == 0)
            {
                await Task.Delay(2000);
                await ProcessAsync(new GameEndQ());
            }
            else
            {
                await Task.Delay(2000);
                Process(new SendQuestionQ());   
            }
        }
        else
        {
            if (round == sendAnswerQ.Round)
            {
                round++;
            
                if (clientNum == 1)
                    client1Life--;
                else if (clientNum == 2)
                    client2Life--;
            }
            else
                return;
            
            await SendToClient1(new SendAnswerA()
            {
                ClientNum = clientNum,
                SentAnswer = sendAnswerQ.Answer,
            });
            await SendToClient2(new SendAnswerA()
            {
                ClientNum = clientNum,
                SentAnswer = sendAnswerQ.Answer,
            });
            
            if(client1Life == 0 || client2Life == 0)
                await ProcessAsync(new GameEndQ());
            else
            {
                await Task.Delay(2000);
                Process(new SendQuestionQ());   
            }
        }
    }
}