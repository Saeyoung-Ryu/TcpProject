using Enum;
using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class LoginReq : Protocol
    {
        [Key(1)] public string NickName { get; set; }
        [Key(2)] public LoginType LoginType { get; set; }
    }

    [MessagePackObject]
    public class LoginRes : ProtocolRes
    {
        [Key(2)] public DateTime CreateTime { get; set; }
        [Key(3)] public string NickName { get; set; }
    }
}
    
