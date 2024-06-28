using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class FindDashBoardReq : Protocol
    {
        [Key(1)] public string DashBoardName { get; set; }
    }

    [MessagePackObject]
    public class FindDashBoardRes : ProtocolRes
    {
        
    }
}
    
