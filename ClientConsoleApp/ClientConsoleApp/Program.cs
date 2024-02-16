using System;
using System.Globalization;
namespace ClientConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            StartTcp();
        }
        static void StartTcp()
        {
            Client client = new Client("127.0.0.1", 3360);
        }
    }
}

/*using System;
using System.Net.Http;
using System.Threading.Tasks;
using MessagePack;
using Protocol2;

namespace ClientConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var loadDataReq = new LoadDataReq
            {
                ProtocolId = ProtocolId.LoadData,
                NickName = "SAMY1234"
            };
            
            var res = await HttpManager.SendHttpServerRequestAsync(loadDataReq);
            var a = (LoadDataRes) res;
            Console.WriteLine(a.NickName);
        }

        static async Task<ProtocolRes> SendHttpServerRequestAsync<T>(T protocol)
        {
            Console.WriteLine("Here");
            // Create an instance of LoadDataReq with sample data

            ProtocolReq requestData = new ProtocolReq
            {
                Protocol = (Protocol2.Protocol)(object)protocol
            };

            // Serialize the request data to MessagePack format
            byte[] requestBytes = MessagePackSerializer.Serialize(requestData);

            // Specify the server URL
            string serverUrl = "http://localhost:8080"; // Adjust the URL based on your server configuration
            Console.WriteLine("Here1");

            // Send the HTTP request to the server
            using (var httpClient = new HttpClient())
            using (var content = new ByteArrayContent(requestBytes))
            {
                Console.WriteLine("Here33");
                content.Headers.Add("Content-Type", "application/octet-stream");

                Console.WriteLine(serverUrl);
                Console.WriteLine(content.ToString());
                var response = await httpClient.PostAsync($"{serverUrl}/", content);
                Console.WriteLine("Here44");

                // Check if the request was successful (status code 200)
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Here2");
                    // Read the response content
                    byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();

                    Console.WriteLine("Here3");
                    // Deserialize the response data from MessagePack format
                    var responseDataRes = MessagePackSerializer.Deserialize<ProtocolRes>(responseBytes);
                    var responseData = responseDataRes;

                    return responseData;
                    // Process the response data
                    var a = (LoadDataRes) responseData;
                    return a;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }
        }
    }
}*/