namespace Protocol;

public class ExitQ : Protocol
{
    public int ClientNum { get; set; }
    public ExitQ() : base(ProtocolId.ExitQ) { }
}

public class ExitA : Protocol
{
    
    public ExitA() : base(ProtocolId.ExitA) { }
}