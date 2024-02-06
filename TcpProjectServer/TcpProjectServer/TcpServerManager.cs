using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpProjectServer;
using Protocol;

public class TcpServerManager
{
    private static TcpListener tcpListener;
    
    public static Queue<TcpClient> clients = new Queue<TcpClient>();
    
    public static Queue<Remote> remoteQueue = new Queue<Remote>();

    public static async Task StartServer(int port)
    {
        tcpListener = new TcpListener(IPAddress.Any, port);
        tcpListener.Start();
        Console.WriteLine($"Server started. Listening on port {((IPEndPoint)tcpListener.LocalEndpoint).Port}");

        for (int i = 0; i < 50; i++)
        {
            Remote remote = new Remote();
            remoteQueue.Enqueue(remote);
        }
        
        await Task.Run(AcceptClients);
    }

    private static async Task AcceptClients()
    {
        while (true)
        {
            TcpClient client = await tcpListener.AcceptTcpClientAsync();
            Console.WriteLine($"Client connected: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

            clients.Enqueue(client);

            if (clients.Count == 2)
            {
                bool isAllConnected = true;
                
                // 매칭중 튕겼을때 큐에서 빼내주기
                foreach (var tcpClient in new[] {clients.Dequeue(), clients.Dequeue()})
                {
                    if (tcpClient.Client.Poll(0, SelectMode.SelectRead))
                        isAllConnected = false;
                    else
                        clients.Enqueue(tcpClient);
                }
                
                if (!isAllConnected)
                    continue;
                
                Console.WriteLine("2 clients connected");
                await Task.Run(() => HandleClients(clients.Dequeue(), clients.Dequeue()));
            }
        }
    }

    private static void HandleClients(TcpClient client1, TcpClient client2)
    {
        Remote remote;
        Thread thread = new Thread(() =>
        {
            remote = remoteQueue.Dequeue();
            remote.Run(client1, client2);
        });
        thread.Start();
    }
}