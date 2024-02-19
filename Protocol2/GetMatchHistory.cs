using Enum;
using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class GetMatchHistoryReq : Protocol
    {
        [Key(1)] public string NickName { get; set; }
    }

    [MessagePackObject]
    public class GetMatchHistoryRes : ProtocolRes
    {
        [Key(1)] public List<Dictionary<WinLoseType, string>> MatchHistoryListDic { get; set; }
    }
}
    
