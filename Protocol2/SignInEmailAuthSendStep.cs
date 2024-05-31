using Enum;
using MessagePack;

namespace Protocol2
{
    [MessagePackObject]
    public class SignInEmailAuthSendStepReq : Protocol
    {
        [Key(1)] public string Email { get; set; }
        [Key(2)] public LoginType LoginType { get; set; }
    }

    [MessagePackObject]
    public class SignInEmailAuthSendStepRes : ProtocolRes
    {
        [Key(2)] public bool AuthResult { get; set; }
    }
}
    
