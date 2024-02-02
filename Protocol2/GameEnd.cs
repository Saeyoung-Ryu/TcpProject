using MessagePack;

namespace Protocol;

[MessagePackObject]
public class GameEndQ : Protocol
{
    
    
    public GameEndQ() : base(ProtocolId.GameEndQ) { }
}

[MessagePackObject]
public class GameEndA : Protocol
{
    [Key(1)] public bool IsWinner { get; set; }
    
    public GameEndA() : base(ProtocolId.GameEndA) { }
}