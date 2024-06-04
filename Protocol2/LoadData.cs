using Common;
using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class LoadDataReq : Protocol
    {
        [Key(1)] public Player Player { get; set; }
    }

    [MessagePackObject]
    public class LoadDataRes : ProtocolRes
    {
        [Key(2)] public PlayerAttendance PlayerAttendance { get; set; }
    }
}
    
