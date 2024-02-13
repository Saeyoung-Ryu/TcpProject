using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpProjectServer;
using Protocol;

public class TcpServerManager
{
    private static TcpListener tcpListener;
    
    private static SemaphoreSlim semaphore = new SemaphoreSlim(2); // Limit to 2 simultaneous connections. Semaphore 는 raceCondition 방지
    public static SemaphoreSlim semaphore1 = new SemaphoreSlim(0); // Semaphore to signal availability of Remote objects
    
    // Use ConcurrentQueue for thread-safe access
    public static ConcurrentQueue<TcpClient> clients = new ConcurrentQueue<TcpClient>();
    
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
        
        semaphore1.Release(remoteQueue.Count);
        
        await Task.Run(AcceptClients);
    }

    private static async Task AcceptClients()
    {
        while (true)
        {
            // Wait for semaphore to allow new connection
            await semaphore.WaitAsync();
    
            TcpClient client = await tcpListener.AcceptTcpClientAsync();
            Console.WriteLine($"Client connected: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");
    
            clients.Enqueue(client);
    
            // Start handling clients if there are at least two in the queue
            if (clients.Count == 2)
            {
                bool isAllConnected = true;
    
                TcpClient client1 = null;
                TcpClient client2 = null;
                
                var tryDequeueResult= clients.TryDequeue(out client1) && clients.TryDequeue(out client2);
                if (!tryDequeueResult)
                    continue;
    
                // 매칭중 튕겼을때 큐에서 빼내주기
                foreach (var tcpClient in new[] {client1, client2})
                {
                    if (tcpClient.Client.Poll(0, SelectMode.SelectRead))
                        isAllConnected = false;
                    else
                    {
                        clients.Enqueue(tcpClient);
                        semaphore.Release(1);
                    }
                }
                
                if (!isAllConnected)
                    continue;
                
                Console.WriteLine("2 clients connected");
                // await Task.Run(() => HandleClients(clients.Dequeue(), clients.Dequeue()));
    
                await Task.Run(HandleNextClients);
            }
        }
    }
    
    private static async Task HandleNextClients()
    {
        try
        {
            // Dequeue two clients and release semaphore
            semaphore.Release(2);

            // Dequeue the clients and handle them
            if (clients.TryDequeue(out TcpClient client1) && clients.TryDequeue(out TcpClient client2))
            {
                Console.WriteLine("2 clients connected");
                await Task.Run(() => HandleClients(client1, client2));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error handling clients: {ex.Message}");
        }
    }
    
    private static void HandleClients(TcpClient client1, TcpClient client2)
    {
        // Wait for the semaphore to indicate availability of Remote object
        semaphore1.Wait();

        Console.WriteLine(semaphore1.CurrentCount);
        // Dequeue a Remote object safely
        if (remoteQueue.TryDequeue(out Remote remote))
        {
            remote.Run(client1, client2);
        }
        else
        {
            Console.WriteLine("Failed to dequeue Remote object.");
        }
    }
}