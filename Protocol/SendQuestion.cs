namespace Protocol;

public class SendQuestionQ : Protocol
{
    
    
    public SendQuestionQ() : base(ProtocolId.SendQuestionQ) { }
}

public class SendQuestionA : Protocol
{
    public int Stage { get; set; }
    public int Client1Life { get; set; }
    public int Client2Life { get; set; }
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
    
    public SendQuestionA() : base(ProtocolId.SendQuestionA) { }
}