using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using MessagePack;
using MessagePack.Resolvers;
using Protocol2;

namespace HttpServer
{
    public class Route
    {
        private readonly RequestDelegate _next;

        public Route(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // blazor 요청 /Tool/~ 로 들어오는거 예외처리
            if (context.Request.Path.Value != "/")
            {
                await _next(context);
                return;
            }
            
            using (MemoryStream ms = new MemoryStream())
            {
                await context.Request.Body.CopyToAsync(ms);
                byte[] requestData = ms.ToArray();
                    
                // 추상클래스는 형변환 불가능하므로 ProcotoclReq를 따로 만들어 안에 Protocol을 넣어줌
                var protocolReq = MessagePackSerializer.Deserialize<ProtocolReq>(requestData);
                var protocolRes = await Service.Service.ProcessAsync(context, protocolReq.Protocol);
                byte[] responseData = MessagePackSerializer.Serialize(protocolRes);
                
                await context.Response.Body.WriteAsync(responseData);
            }
        }
    }
}
