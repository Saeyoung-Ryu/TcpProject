using MessagePack;

namespace Protocol;

[MessagePackObject]
public class SendQuestionQ : Protocol
{
    
    
    public SendQuestionQ() : base(ProtocolId.SendQuestionQ) { }
}

[MessagePackObject]
public class SendQuestionA : Protocol
{
    [Key(1)] public int Round { get; set; }
    [Key(2)] public int Client1Life { get; set; }
    [Key(3)] public int Client2Life { get; set; }
    [Key(4)] public int FirstNumber { get; set; }
    [Key(5)] public int SecondNumber { get; set; }
    
    public SendQuestionA() : base(ProtocolId.SendQuestionA) { }
}