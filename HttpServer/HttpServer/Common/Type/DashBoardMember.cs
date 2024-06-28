using Enum;
using Newtonsoft.Json;

namespace Common;

public class DashBoardMember
{
    public int DashBoardSeq { get; set; }
    public string Puuid { get; set; }
    public string Name { get; set; }
    public bool Enable { get; set; }
    
    public int SupWinCount { get; set; }
    public int SupLoseCount { get; set; }
    public int AdcWinCount { get; set; }
    public int AdcLoseCount { get; set; }
    public int MidWinCount { get; set; }
    public int MidLoseCount { get; set; }
    public int JgWinCount { get; set; }
    public int JgLoseCount { get; set; }
    public int TopWinCount { get; set; }
    public int TopLoseCount { get; set; }
    
    public int TotalWinCount { get { return SupWinCount + AdcWinCount + MidWinCount + JgWinCount + TopWinCount; } }
    public int TotalLoseCount  { get { return SupLoseCount + AdcLoseCount + MidLoseCount + JgLoseCount + TopLoseCount; } }
}