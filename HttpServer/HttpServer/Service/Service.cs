using System.Reflection;
using Protocol2;
using System.Threading.Tasks;
using HttpServer;
using Microsoft.AspNetCore.Http;

namespace Service
{
    public interface IService
    {
        ProtocolId ProtocolId { get; set; }
        Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request);
    }

    public class Service
    {
        private static Dictionary<ProtocolId, IService> dicHandler = new Dictionary<ProtocolId, IService>();
        
        public static void Initialize()
        {
            Type[] types = Assembly.GetEntryAssembly().GetTypes();
            foreach (var t in types)
            {
                if (t.GetInterfaces().Contains(typeof(IService)) == false)
                    continue;

                var typeInfo = t.GetTypeInfo();
                if (typeInfo.GetCustomAttribute<ProtocolHandlerAttribute>() != null)
                {
                    var instance = (IService)Activator.CreateInstance(t);
                    dicHandler.Add(instance.ProtocolId, instance);
                }
            }
        }
        
        public static async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol req)
        {
            if (dicHandler.TryGetValue(req.ProtocolId, out var handler) == false)
            {
                if (handler == null)
                    throw new Exception($"Unknown Protocol : {req.ProtocolId}");
            }
            return await handler.ProcessAsync(context, req);
        }
    }
}