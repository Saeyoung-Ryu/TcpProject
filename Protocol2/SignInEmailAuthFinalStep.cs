using Enum;
using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class SignInEmailAuthFinalStepReq : Protocol
    {
        [Key(1)] public string Password { get; set; }
        [Key(2)] public string NickName { get; set; }
        [Key(3)] public string Email { get; set; }
    }

    [MessagePackObject]
    public class SignInEmailAuthFinalStepRes : ProtocolRes
    {
        [Key(2)] public bool FinalResult { get; set; }
    }
}
    
