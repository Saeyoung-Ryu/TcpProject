namespace Protocol
{
    public class Protocol
    {
        public ProtocolId ProtocolId { get; set; }

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
        EnterQ = 1,
        EnterA = 2,
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