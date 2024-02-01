namespace Protocol;

public class GameEndQ : Protocol
{
    
    
    public GameEndQ() : base(ProtocolId.GameEndQ) { }
}

public class GameEndA : Protocol
{
    public bool IsWinner { get; set; }
    
    public GameEndA() : base(ProtocolId.GameEndA) { }
}