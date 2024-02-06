using MessagePack;

namespace Protocol2
{
	public enum ProtocolId
	{
		None = 0,
		LoadData = 1,
	}
	
	[MessagePackObject]
	[Union(0, typeof(LoadDataReq))]
	public abstract class Protocol
	{
		[Key(0)] public ProtocolId ProtocolId { get; set; }

		public Protocol() {}
		public Protocol(ProtocolId protocolId) { ProtocolId = protocolId; }
	}
	
	[MessagePackObject]
	[Union(0, typeof(LoadDataRes))]
	public abstract class ProtocolRes
	{
		[Key(0)] public ProtocolId ProtocolId { get; set; }

		public ProtocolRes() {}
		public ProtocolRes(ProtocolId protocolId) { ProtocolId = protocolId; }
	}
}
