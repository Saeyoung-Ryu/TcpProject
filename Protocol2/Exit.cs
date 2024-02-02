using MessagePack;

namespace Protocol;

[MessagePackObject]
public class ExitQ : Protocol
{
    [Key(1)] public int ClientNum { get; set; }
    public ExitQ() : base(ProtocolId.ExitQ) { }
}

[MessagePackObject]
public class ExitA : Protocol
{
    
    public ExitA() : base(ProtocolId.ExitA) { }
}