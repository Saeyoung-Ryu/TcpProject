using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class EditNicknameReq : Protocol
    {
        [Key(1)] public string OriginalNickname { get; set; }
        [Key(2)] public string ChangedNickname { get; set; }
    }

    [MessagePackObject]
    public class EditNicknameRes : ProtocolRes
    {
        [Key(1)] public bool Success { get; set; }
    }
}
    
