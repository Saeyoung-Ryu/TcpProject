using Protocol2;
using System.Threading.Tasks;

namespace YourNamespace.Service
{
    public interface IService
    {
        ProtocolId ProtocolId { get; set; }

        Task ProcessAsync();
    }
}