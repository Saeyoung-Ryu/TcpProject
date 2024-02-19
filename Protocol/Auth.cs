using MessagePack;

namespace Protocol;

[MessagePackObject]
public class AuthQ : Protocol
{
    [Key(1)] public int ClientNum { get; set; }
    [Key(2)] public string Nickname { get; set; }
    
    public AuthQ() : base(ProtocolId.AuthQ) { }
}

[MessagePackObject]
public class AuthA : Protocol
{
    [Key(1)] public int ClientNum { get; set; }
    
    public AuthA() : base(ProtocolId.AuthA) { }
}