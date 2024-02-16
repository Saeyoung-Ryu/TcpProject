using System;
using System.Net.Http;
using System.Threading.Tasks;
using MessagePack;
using Protocol2;

namespace TcpProjectServer;

public class HttpManager
{
    public static async Task<ProtocolRes?> SendHttpServerRequestAsync<T>(T protocol)
    {
        ProtocolReq requestData = new ProtocolReq
        {
            Protocol = (Protocol2.Protocol)(object)protocol
        };

        byte[] requestBytes = MessagePackSerializer.Serialize(requestData);
        string serverUrl = "http://localhost:8080"; // Adjust the URL based on your server configuration
        
        using (var httpClient = new HttpClient())
        using (var content = new ByteArrayContent(requestBytes))
        {
            content.Headers.Add("Content-Type", "application/octet-stream");
            var response = await httpClient.PostAsync($"{serverUrl}/", content);
            
            if (response.IsSuccessStatusCode)
            {
                byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();

                    // Deserialize the response data from MessagePack format
                var responseDataRes = MessagePackSerializer.Deserialize<ProtocolRes>(responseBytes);
                var responseData = responseDataRes;

                return responseData;
            }
            
            return null;
        }
    }
}