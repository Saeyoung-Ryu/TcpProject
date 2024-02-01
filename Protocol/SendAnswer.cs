namespace Protocol;

public class SendAnswerQ : Protocol // client -> server
{
    public int Stage { get; set; }
    public int ClientNum { get; set; }
    public int Answer { get; set; }
    
    public SendAnswerQ() : base(ProtocolId.SendAnswerQ) { }
}

public class SendAnswerA : Protocol // server -> allClient
{
    public int ClientNum { get; set; }
    public int SentAnswer { get; set; }
    
    public SendAnswerA() : base(ProtocolId.SendAnswerA) { }
}