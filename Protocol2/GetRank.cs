using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class GetRankReq : Protocol
    {
        [Key(1)] public string NickName { get; set; }
    }

    [MessagePackObject]
    public class GetRankRes : ProtocolRes
    {
        [Key(1)] public int WinCount { get; set; }
        [Key(2)] public int LoseCount { get; set; }
        [Key(3)] public int Point { get; set; }
        [Key(4)] public int Ranking { get; set; }
    }
}
    
