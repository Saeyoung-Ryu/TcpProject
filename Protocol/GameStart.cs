using MessagePack;

namespace Protocol;

[MessagePackObject]
public class GameStartQ : Protocol
{
    
    
    public GameStartQ() : base(ProtocolId.GameStartQ) { }
}

[MessagePackObject]
public class GameStartA : Protocol
{
    [Key(1)] public int ClientNum { get; set; }
    [Key(2)] public int LoadingTime { get; set; }
    
    public GameStartA() : base(ProtocolId.GameStartA) { }
}