using MessagePack;


namespace Protocol
{
    [MessagePackObject]
    public class Protocol
    {
        [Key(0)] public ProtocolId ProtocolId { get; set; }

        public Protocol()
        {
        }

        public Protocol(ProtocolId protocolId)
        {
            ProtocolId = protocolId;
        }
    }

    public enum ProtocolId
    {
        AuthQ = 1,
        AuthA = 2,
        GameStartQ = 3,
        GameStartA = 4,
        SendQuestionQ = 5,
        SendQuestionA = 6,
        SendAnswerQ = 7,
        SendAnswerA = 8,
        GameEndQ = 9,
        GameEndA = 10,
        ReMatchQ = 11,
        ReMatchA = 12,
        ExitQ = 13,
        ExitA = 14,
        DisconnectedQ = 15,
        DisconnectedA = 16
    }
}