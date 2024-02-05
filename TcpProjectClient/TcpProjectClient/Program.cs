/*using System;
using System.Globalization;

namespace TcpProjectClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            Client client = new Client("127.0.0.1", 3360);
            while (true)
            {

            }
        }
    }
}*/

using System;
using System.Net.Http;
using System.Threading.Tasks;
using MessagePack;
using Protocol2;

namespace HttpClientExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await SendHttpRequestAsync();
        }

        static async Task SendHttpRequestAsync()
        {
            // Create an instance of LoadDataReq with sample data
            var requestData = new LoadDataReq
            {
                UserId = 123
            };

            // Serialize the request data to MessagePack format
            byte[] requestBytes = MessagePackSerializer.Serialize(requestData);

            // Specify the server URL
            string serverUrl = "http://localhost:8080"; // Adjust the URL based on your server configuration

            // Send the HTTP request to the server
            using (var httpClient = new HttpClient())
            using (var content = new ByteArrayContent(requestBytes))
            {
                content.Headers.Add("Content-Type", "application/octet-stream");

                var response = await httpClient.PostAsync($"{serverUrl}/", content);

                // Check if the request was successful (status code 200)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();

                    // Deserialize the response data from MessagePack format
                    var responseData = MessagePackSerializer.Deserialize<LoadDataRes>(responseBytes);

                    // Process the response data
                    Console.WriteLine($"User ID: {responseData.UserId}");
                    Console.WriteLine($"User Name: {responseData.UserName}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
        }
    }
}
