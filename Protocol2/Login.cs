using Common;
using Enum;
using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class LoginReq : Protocol
    {
        [Key(1)] public string Email { get; set; }
        [Key(2)] public string Password { get; set; }
        [Key(3)] public LoginType LoginType { get; set; }
    }

    [MessagePackObject]
    public class LoginRes : ProtocolRes
    {
        [Key(2)] public DateTime CreateTime { get; set; }
        [Key(3)] public Player Player { get; set; }
        [Key(4)] public List<string> ManagingDashBoardNames { get; set; }
    }
}
    
