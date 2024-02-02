using System;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using MessagePack;
using Newtonsoft.Json;
using Protocol;

namespace TcpProjectClient;

public partial class Client
{
    private TcpClient tcpClient;
    private int myClientNumber = 0;
    private int stage = 0;

    private bool canWrite = false;

    public Client(string serverIp, int serverPort)
    {
        tcpClient = new TcpClient(serverIp, serverPort);
        Console.WriteLine($"Connected to server: {serverIp}:{serverPort}");

        Task.Run(ProcessReceiveAsync);
        Task.Run(() => ProcessSendAsync());
    }
    
    private void Send<T>(T data)
    {
        // MessagePack 사용
        byte[] buffer = MessagePackSerializer.Serialize(data);
        tcpClient.GetStream().Write(buffer, 0, buffer.Length);
    }

    public async Task ProcessReceiveAsync()
    {
        try
        {
            using (MemoryStream stream = new MemoryStream())
            {
                while (true)
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = await tcpClient.GetStream().ReadAsync(buffer, 0, buffer.Length);
    
                    if (bytesRead <= 0)
                    {
                        break;
                    }
    
                    await stream.WriteAsync(buffer, 0, bytesRead);
                    stream.Position = 0;
    
                    // Use MessagePack for deserialization
                    try
                    {
                        Protocol.Protocol? protocol = MessagePackSerializer.Deserialize<Protocol.Protocol>(stream);
    
                        switch (protocol?.ProtocolId)
                        {
                            case ProtocolId.EnterA:
                                Process(MessagePackSerializer.Deserialize<EnterA>(new MemoryStream(stream.ToArray())));
                                break;
                            case ProtocolId.GameStartA:
                                await ProcessAsync(MessagePackSerializer.Deserialize<GameStartA>(new MemoryStream(stream.ToArray())));
                                break;
                            case ProtocolId.SendQuestionA:
                                await ProcessAsync(MessagePackSerializer.Deserialize<SendQuestionA>(new MemoryStream(stream.ToArray())));
                                break;
                            case ProtocolId.SendAnswerA:
                                Process(MessagePackSerializer.Deserialize<SendAnswerA>(new MemoryStream(stream.ToArray())));
                                break;
                            case ProtocolId.GameEndA:
                                Process(MessagePackSerializer.Deserialize<GameEndA>(new MemoryStream(stream.ToArray())));
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deserializing MessagePack data: {ex.Message}");
                    }
    
                    stream.SetLength(0);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in Receive method: {ex.Message}");
        }
        
    }
    
    public async Task ProcessSendAsync()
    {
        while (true)
        {
            while (canWrite)
            {
                var answerString = await ReadInputAsync();

                if (int.TryParse(answerString, out var answer))
                {
                    var sendAnswerQ = new SendAnswerQ
                    {
                        Round = stage,
                        ClientNum = myClientNumber,
                        Answer = answer
                    };
                    Send(sendAnswerQ);
                    canWrite = false;
                }
            }
        }
        
    }

    static Task<string?> ReadInputAsync()
    {
        return Console.In.ReadLineAsync();
    }
}