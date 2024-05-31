using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class LoadDataReq : Protocol
    {
        [Key(1)] public string Email { get; set; }
        [Key(2)] public string Password { get; set; }
    }

    [MessagePackObject]
    public class LoadDataRes : ProtocolRes
    {
        [Key(2)] public DateTime CreateTime { get; set; }
        [Key(3)] public string NickName { get; set; }
    }
}
    
