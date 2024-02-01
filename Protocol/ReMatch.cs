namespace Protocol;

public class ReMatchQ : Protocol
{
    public int ClientNum { get; set; }
    public bool DoReMatch { get; set; }
    public ReMatchQ() : base(ProtocolId.ReMatchQ) { }
}

public class ReMatchA : Protocol
{
    public int ClientNum { get; set; }
    
    public ReMatchA() : base(ProtocolId.ReMatchA) { }
}