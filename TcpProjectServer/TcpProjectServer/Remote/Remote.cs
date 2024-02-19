using System.Net.Sockets;
using Common;
using MessagePack;
using Protocol;

namespace TcpProjectServer;

    public partial class Remote
    {
        public static SemaphoreSlim roundSemaphore = new SemaphoreSlim(1);
        
        private TcpClient client1;
        private TcpClient client2;
        public string client1Nickname;
        public string client2Nickname;
        
        public int client1Life = int.Parse(ServerVariable.Life);
        public int client2Life = int.Parse(ServerVariable.Life);
        public int round = 1;
        public int firstNumber;
        public int secondNumber;
        
        public async Task RunAsync(TcpClient tcpClient1, TcpClient tcpClient2)
        {
            Reset();
            
            client1 = tcpClient1;
            client2 = tcpClient2;

            Task.Run(async () => await ProcessReceiveAsync(client1));
            Task.Run(async () => await ProcessReceiveAsync(client2));

            await SendAuthAAsync();
            
            ProcessAsync(new GameStartQ());
        }

        public async Task SendAuthAAsync()
        {
            AuthA authA = new AuthA();
            authA.ClientNum = 1;
            await SendToClient1(authA);
            authA.ClientNum = 2;
            await SendToClient2(authA);
        }
        public async Task ProcessReceiveAsync(TcpClient tcpClient)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                while (true)
                {
                    byte[] buffer = new byte[4096];
        
                    int bytesRead;
                    while ((bytesRead = await tcpClient.GetStream().ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                        break;
                    }
                    
                    if (bytesRead == 0)
                    {
                        Console.WriteLine("Client disconnected");
                        return;
                    }
                    
                    stream.Position = 0;
                    
                    Protocol.Protocol? protocol = null;
                    try
                    {
                        protocol = MessagePackSerializer.Deserialize<Protocol.Protocol>(stream);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deserializing MessagePack data: {ex.Message}");
                        return;
                    }

                    switch (protocol?.ProtocolId)
                    {
                        case ProtocolId.SendAnswerQ:
                            await ProcessAsync(MessagePackSerializer.Deserialize<SendAnswerQ>(new MemoryStream(stream.ToArray())));
                            break;
                        case ProtocolId.AuthQ:
                            await ProcessAsync(MessagePackSerializer.Deserialize<AuthQ>(new MemoryStream(stream.ToArray())));
                            break;
                        // Protocol 여기다 추가
                    }
        
                    // Reset the stream
                    stream.SetLength(0);
                }
            }
        }
        
        private void SendAll<T>(T data)
        {
            SendToClient1(data);
            SendToClient2(data);
        }

        private async Task SendToClient1<T>(T data)
        {
            if (CheckIfDisconnected(client1))
            {
                Console.WriteLine("Client 1 disconnected");
                return;
            }
                
            
            byte[] buffer = MessagePackSerializer.Serialize(data);
            await client1.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }
        
        private async Task SendToClient2<T>(T data)
        {
            if(CheckIfDisconnected(client2))
            {
                Console.WriteLine("Client 2 disconnected");
                return;
            }
            
            byte[] buffer = MessagePackSerializer.Serialize(data);
            await client2.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        private void Reset()
        {
            roundSemaphore = new SemaphoreSlim(1);
            client1Life = 5;
            client2Life = 5;
            round = 1;
        }

        private bool CheckIfDisconnected(TcpClient tcpClient)
        {
            if (tcpClient.Client.Poll(0, SelectMode.SelectRead))
                return true;
            
            return false;
        }
    }
