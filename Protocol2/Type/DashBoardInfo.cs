using MessagePack;

namespace Protocol2.Type;

[MessagePackObject]
public class DashBoardInfo
{
    [Key(0)] public int DashBoardSeq { get; set; }
    [Key(1)] public string Name { get; set; }
    [Key(2)] public DateTime CreateTime { get; set; }
    [Key(3)] public string MasterName { get; set; }
    [Key(4)] public List<string> ManagerNameList { get; set; }
    
    [Key(5)] public List<string> MemberTotalRankOrderByName { get; set; }
    [Key(6)] public List<string> MemberSupRankOrderByName { get; set; }
    [Key(7)] public List<string> MemberAdcRankOrderByName { get; set; }
    [Key(8)] public List<string> MemberMidRankOrderByName { get; set; }
    [Key(9)] public List<string> MemberJgRankOrderByName { get; set; }
    [Key(10)] public List<string> MemberTopRankOrderByName { get; set; }
}