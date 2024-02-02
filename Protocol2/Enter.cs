using MessagePack;

namespace Protocol;

[MessagePackObject]
public class EnterQ : Protocol
{

    
    public EnterQ() : base(ProtocolId.EnterQ) { }
}

[MessagePackObject]
public class EnterA : Protocol
{
    public EnterA() : base(ProtocolId.EnterA) { }
}