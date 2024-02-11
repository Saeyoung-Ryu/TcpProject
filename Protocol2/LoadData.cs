using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class LoadDataReq : Protocol
    {
        [Key(1)] public int UserId { get; set; }
    }

    [MessagePackObject]
    public class LoadDataRes : ProtocolRes
    {
        [Key(1)] public int UserId { get; set; }
        [Key(2)] public string UserName { get; set; }
    }
}
    
