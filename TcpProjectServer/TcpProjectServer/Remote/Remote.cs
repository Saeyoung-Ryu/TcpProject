using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using TcpProjectServer;
using MessagePack;
using Protocol;

namespace TcpProjectServer;

    public partial class Remote
    {
        private TcpClient client1;
        private TcpClient client2;
        
        public int client1Life = 5;
        public int client2Life = 5;
        public int stage = 1;
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
                    while ((bytesRead = tcpClient.GetStream().Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                        break;
                    }
                    
                    if (tcpClient.Client.Poll(0, SelectMode.SelectRead))
                    {
                        Console.WriteLine("Connection closed by the remote endpoint");
                        Process(new DisconnectedQ());
                        break;
                    }
                    
                    stream.Position = 0;
                    string jsonData = Encoding.UTF8.GetString(stream.ToArray());
                    Console.WriteLine(jsonData);
                    Protocol.Protocol? protocol = null;
                    try
                    {
                        protocol = JsonConvert.DeserializeObject<Protocol.Protocol>(jsonData) ?? null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                    }
                    
                    if (protocol == null)
                    {
                        Console.WriteLine("It is null");
                    }
                    Console.WriteLine(protocol.ProtocolId + "Recieved");
                    if(protocol == null)
                        return;
                    
                    if (protocol.ProtocolId == ProtocolId.SendAnswerQ)
                    {
                        protocol = JsonConvert.DeserializeObject<SendAnswerQ>(jsonData);
                        await ProcessAsync((SendAnswerQ)protocol);
                    }
                    if (protocol.ProtocolId == ProtocolId.ExitQ)
                    {
                        protocol = JsonConvert.DeserializeObject<ExitQ>(jsonData);
                        Process((ExitQ)protocol);
                    }
                    if (protocol.ProtocolId == ProtocolId.ReMatchQ)
                    {
                        protocol = JsonConvert.DeserializeObject<ReMatchQ>(jsonData);
                        Process((ReMatchQ)protocol);
                    }
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
            // json 사용
            string jsonData = JsonConvert.SerializeObject(data);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
            client1.GetStream().Write(buffer, 0, buffer.Length);
        }
        private void SendToClient2<T>(T data)
        {
            // json 사용
            string jsonData = JsonConvert.SerializeObject(data);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
            client2.GetStream().Write(buffer, 0, buffer.Length);
        }

        private void Reset()
        {
            client1Life = 5;
            client2Life = 5;
            stage = 1;
        }
    }
