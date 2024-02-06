using MessagePack;

namespace Protocol2;

[MessagePackObject]
public class ProtocolReq
{
    [Key(0)] public Protocol Protocol { get; set; }
}