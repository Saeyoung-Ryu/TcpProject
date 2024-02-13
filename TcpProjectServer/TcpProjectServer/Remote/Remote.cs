using System.Net.Sockets;
using MessagePack;
using Protocol;

namespace TcpProjectServer;

    public partial class Remote
    {
        private TcpClient client1;
        private TcpClient client2;
        
        public int client1Life = 5;
        public int client2Life = 5;
        public int round = 1;
        public int firstNumber;
        public int secondNumber;
        
        public void Run(TcpClient tcpClient1, TcpClient tcpClient2)
        {
            Reset();
            
            client1 = tcpClient1;
            client2 = tcpClient2;

            Task.Run(async () => await ProcessReceiveAsync(client1));
            Task.Run(async () => await ProcessReceiveAsync(client2));

            ProcessAsync(new GameStartQ());
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
                        case ProtocolId.EnterQ:
                            Process(MessagePackSerializer.Deserialize<EnterQ>(new MemoryStream(stream.ToArray())));
                            break;
                        case ProtocolId.SendAnswerQ:
                            await ProcessAsync(MessagePackSerializer.Deserialize<SendAnswerQ>(new MemoryStream(stream.ToArray())));
                            break;
                        case ProtocolId.ExitQ:
                            Process(MessagePackSerializer.Deserialize<ExitQ>(new MemoryStream(stream.ToArray())));
                            break;
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

        private void SendToClient1<T>(T data)
        {
            if (CheckIfDisconnected(client1))
                return;
            
            byte[] buffer = MessagePackSerializer.Serialize(data);
            client1.GetStream().Write(buffer, 0, buffer.Length);
        }
        
        private void SendToClient2<T>(T data)
        {
            if(CheckIfDisconnected(client2))
                return;
            
            byte[] buffer = MessagePackSerializer.Serialize(data);
            client2.GetStream().Write(buffer, 0, buffer.Length);
        }

        private void Reset()
        {
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
