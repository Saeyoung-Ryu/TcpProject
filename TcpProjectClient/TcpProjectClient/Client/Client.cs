using System;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Protocol;

namespace TcpProjectClient;

public partial class Client
{
    private TcpClient tcpClient;
    private int myClientNumber = 0;
    private int stage = 0;

    private bool canWrite = false;
    // private Thread answerThread;

    public Client(string serverIp, int serverPort)
    {
        tcpClient = new TcpClient(serverIp, serverPort);
        Console.WriteLine($"Connected to server: {serverIp}:{serverPort}");

        Thread receiveThread = new Thread(() => Task.Run(ProcessAsync));
        Thread answerThread = new Thread(() => Task.Run(() => ProcessSendAsync()));
        // Thread disconnectionThread = new Thread(() => Task.Run(ProcessDisconnectionAsync));
        receiveThread.Start();
        answerThread.Start();
        // disconnectionThread.Start();
    }

    public void Send<T>(T data)
    {
        try
        {
            string jsonData = JsonConvert.SerializeObject(data);
            Console.WriteLine(jsonData);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
            tcpClient.GetStream().Write(buffer, 0, buffer.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in SendToServer method: {ex.Message}");
        }
    }
    
    public async Task ProcessAsync()
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
                    string jsonData = Encoding.UTF8.GetString(stream.ToArray());
    
                    if (TryDeserialize(jsonData, out Protocol.Protocol? protocol))
                    {
                        await ProcessProtocol(protocol, jsonData);
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
    
    public async Task ProcessDisconnectionAsync()
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
                    string jsonData = Encoding.UTF8.GetString(stream.ToArray());
    
                    if (TryDeserialize(jsonData, out Protocol.Protocol? protocol))
                    {
                        await ProcessDisconnectionProtocol(protocol, jsonData);
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

    private bool TryDeserialize(string jsonData, out Protocol.Protocol? protocol)
    {
        try
        {
            protocol = JsonConvert.DeserializeObject<Protocol.Protocol>(jsonData) ?? null;
            return protocol != null;
        }
        catch (JsonException)
        {
            protocol = null;
            return false;
        }
    }

    private async Task ProcessDisconnectionProtocol(Protocol.Protocol? protocol, string jsonData)
    {
        switch (protocol?.ProtocolId)
        {
            case ProtocolId.DisconnectedA:
                Process(JsonConvert.DeserializeObject<DisconnectedA>(jsonData) as DisconnectedA);
                break;
        }
    }
    private async Task ProcessProtocol(Protocol.Protocol? protocol, string jsonData)
    {
        switch (protocol?.ProtocolId)
        {
            case ProtocolId.EnterA:
                Process(JsonConvert.DeserializeObject<EnterA>(jsonData) as EnterA);
                break;
            case ProtocolId.GameStartA:
                Process(JsonConvert.DeserializeObject<GameStartA>(jsonData) as GameStartA);
                break;
            case ProtocolId.SendQuestionA:
                await ProcessAsync(JsonConvert.DeserializeObject<SendQuestionA>(jsonData) as SendQuestionA);
                break;
            case ProtocolId.SendAnswerA:
                Process(JsonConvert.DeserializeObject<SendAnswerA>(jsonData) as SendAnswerA);
                break;
            case ProtocolId.GameEndA:
                Process(JsonConvert.DeserializeObject<GameEndA>(jsonData) as GameEndA);
                break;
            case ProtocolId.ReMatchA:
                Process(JsonConvert.DeserializeObject<ReMatchA>(jsonData) as ReMatchA);
                break;
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
                        Stage = stage,
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