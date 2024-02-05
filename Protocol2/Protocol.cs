using MessagePack;


namespace Protocol2
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

    public class ProtocolRes
    {
        [Key(0)] public ProtocolId ProtocolId { get; set; }

        public ProtocolRes()
        {
        }

        public ProtocolRes(ProtocolId protocolId)
        {
            ProtocolId = protocolId;
        }
    }

    public enum ProtocolId
    {
        LoadData = 1,
    }
}