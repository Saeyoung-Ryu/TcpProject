using Enum;

namespace Common;

public class Player
{
    public long Suid { get; set; }
    public string AccountId { get; set; }
    public LoginType LoginType { get; set; }
    public string Nickname { get; set; }
    public DateTime CreateTime { get; set; }
}