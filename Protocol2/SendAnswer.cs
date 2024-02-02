using MessagePack;

namespace Protocol;

[MessagePackObject]
public class SendAnswerQ : Protocol // client -> server
{
    [Key(1)] public int Stage { get; set; }
    [Key(2)] public int ClientNum { get; set; }
    [Key(3)] public int Answer { get; set; }
    
    public SendAnswerQ() : base(ProtocolId.SendAnswerQ) { }
}

[MessagePackObject]
public class SendAnswerA : Protocol // server -> allClient
{
    [Key(1)] public int ClientNum { get; set; }
    [Key(2)] public int SentAnswer { get; set; }
    
    public SendAnswerA() : base(ProtocolId.SendAnswerA) { }
}