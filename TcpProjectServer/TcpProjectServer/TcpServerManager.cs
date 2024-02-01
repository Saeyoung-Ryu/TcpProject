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

    public static async Task Start(int port)
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