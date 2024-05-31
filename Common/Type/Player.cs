using Enum;

namespace Common;

public class Player
{
    public long Suid { get; set; }
    public string AccountId { get; set; }
    public LoginType LoginType { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordSalt { get; set; }
    public DateTime CreateTime { get; set; }
}