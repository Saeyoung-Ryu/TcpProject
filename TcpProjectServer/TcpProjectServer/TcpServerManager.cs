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
    
    // private static SemaphoreSlim semaphore = new SemaphoreSlim(2); // Limit to 2 simultaneous connections. Semaphore 는 raceCondition 방지
    public static SemaphoreSlim remoteSemaphore = new SemaphoreSlim(0); // Semaphore to signal availability of Remote objects
    
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
        
        remoteSemaphore.Release(remoteQueue.Count);
        
        Task.Run(AcceptClientsAsync);
        await Task.Run(HandleClientsAsync);

        // 쓰레드풀 사용해서 관리
        /*const int threadPoolSize = 3;
        Task[] handleClientsTasks = new Task[threadPoolSize];
        for (int i = 0; i < threadPoolSize; i++)
        {
            handleClientsTasks[i] = Task.Run(HandleClientsAsync);
        }

        // Wait for all tasks to complete
        await Task.WhenAll(handleClientsTasks);*/
    }

    private static void HandleClientsAsync()
    {
        TcpClient? client1 = null;
        TcpClient? client2 = null;
        
        while (true)
        {
            try
            {
                if (clients.Count + (client1 == null ? 0 : 1 ) + (client2 == null ? 0 : 1 ) >= 2)
                {
                    if (client1 == null)
                        clients.TryDequeue(out client1);
                    
                    if (client2 == null)
                        clients.TryDequeue(out client2);
                
                    if (client1 == null || client1.Client.Poll(0, SelectMode.SelectRead))
                        client1 = null;
                    if (client2 == null || client2.Client.Poll(0, SelectMode.SelectRead))
                        client2 = null;

                    if (client1 != null && client2 != null)
                    {
                        Run(client1, client2);
                        client1 = null;
                        client2 = null;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    private static async Task AcceptClientsAsync()
    {
        while (true)
        {
            var tcpClient = await tcpListener.AcceptTcpClientAsync();
            clients.Enqueue(tcpClient);
            Console.WriteLine(clients.Count);
        }
    }
    
    private static void Run(TcpClient client1, TcpClient client2)
    {
        Task.Run(async () =>
        {
            await remoteSemaphore.WaitAsync();
            
            if (remoteQueue.TryDequeue(out Remote remote))
            {
                remote.Run(client1, client2);
            }
            else
            {
                Console.WriteLine("Failed to dequeue Remote object.");
            }
        });
    }
}