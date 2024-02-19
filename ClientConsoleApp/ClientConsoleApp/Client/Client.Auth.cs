using Protocol;

namespace ClientConsoleApp;

public partial class Client
{
    public async Task ProcessAsync(AuthA authA)
    {
        myClientNumber = authA.ClientNum;

        AuthQ authQ = new AuthQ()
        {
            ProtocolId = ProtocolId.AuthQ,
            ClientNum = authA.ClientNum,
            Nickname = Program.Nickname
        };
        
        Send(authQ);
    }
}