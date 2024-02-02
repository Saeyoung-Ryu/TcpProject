using MessagePack;

namespace Protocol;

[MessagePackObject]
public class DisconnectedQ : Protocol
{

    
    public DisconnectedQ() : base(ProtocolId.DisconnectedQ) { }
}

[MessagePackObject]
public class DisconnectedA : Protocol
{
    public int ClientId { get; set; }
    public DisconnectedA() : base(ProtocolId.DisconnectedA) { }
}