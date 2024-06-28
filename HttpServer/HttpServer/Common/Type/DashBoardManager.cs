using Enum;
using Newtonsoft.Json;

namespace Common;

public class DashBoardManager
{
    public long Suid { get; set; }
    public int DashBoardSeq { get; set; }
    public DashBoardPosition Position { get; set; }
    public bool Enable { get; set; }
}