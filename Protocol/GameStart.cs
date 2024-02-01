namespace Protocol;

public class GameStartQ : Protocol
{
    
    
    public GameStartQ() : base(ProtocolId.GameStartQ) { }
}

public class GameStartA : Protocol
{
    public int ClientNum { get; set; }
    public int LoadingTime { get; set; }
    
    public GameStartA() : base(ProtocolId.GameStartA) { }
}