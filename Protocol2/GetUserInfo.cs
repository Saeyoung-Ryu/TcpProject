using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class GetUserInfoQ : Protocol
    {
        [Key(1)] public int UserId { get; set; }
    }

    [MessagePackObject]
    public class GetUserInfoA : Protocol
    {
        [Key(1)] public int UserId { get; set; }

        [Key(2)] public string UserName { get; set; }
    }
}
    
