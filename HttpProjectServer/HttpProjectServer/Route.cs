using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using MessagePack;
using MessagePack.Resolvers;
using Protocol2;

namespace HttpProjectServer
{
    public class Route
    {
        private readonly RequestDelegate _next;

        public Route(RequestDelegate next)
        {
            _next = next;
        }

        /*public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.HasFormContentType && context.Request.Form.ContainsKey("messagePackData"))
            {
                Console.WriteLine("InvokeAsync");
                var messagePackData = context.Request.Form["messagePackData"];
                byte[] requestData = Convert.FromBase64String(messagePackData);

                // Deserialize the MessagePack data
                var protocol = MessagePackSerializer.Deserialize<Protocol>(requestData);

                var protocolRes = await Service.Service.ProcessAsync(context, protocol);
                byte[] responseData = MessagePackSerializer.Serialize(protocolRes);

                // Send the response to the client
                context.Response.ContentType = "application/octet-stream";
                context.Response.ContentLength = responseData.Length;
                await context.Response.Body.WriteAsync(responseData);
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid request");
            }
        }*/
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Invoked!!!");
            if (context.Request.ContentType == "application/octet-stream")
            {
                // Read raw bytes from the request body
                using (MemoryStream ms = new MemoryStream())
                {
                    Console.WriteLine("Here1");
                    await context.Request.Body.CopyToAsync(ms);
                    byte[] requestData = ms.ToArray();

                    // Deserialize the MessagePack data
                    var protocol = MessagePackSerializer.Deserialize<Protocol>(requestData);
                    Console.WriteLine("Here2");
                    Console.WriteLine(protocol.ProtocolId);
                    // Process the request and prepare the response
                    var protocolRes = await Service.Service.ProcessAsync(context, protocol);
                    byte[] responseData = MessagePackSerializer.Serialize(protocolRes);
                    
                    Console.WriteLine("Here3");
                    // Send the response to the client
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.ContentLength = responseData.Length;
                    await context.Response.Body.WriteAsync(responseData);
                    Console.WriteLine("Here4");
                }
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid request");
            }
        }

    }
}
