using MessagePack;

namespace Protocol2
{
	public enum ProtocolId
	{
		None = 0,
		LoadData = 1,
		GetRank = 2,
		SetRank = 3,
	}
	
	[MessagePackObject]
	[Union(0, typeof(LoadDataReq))]
	[Union(1, typeof(GetRankReq))]
	[Union(2, typeof(SetRankReq))]
	public abstract class Protocol
	{
		[Key(0)] public ProtocolId ProtocolId { get; set; }

		public Protocol() {}
		public Protocol(ProtocolId protocolId) { ProtocolId = protocolId; }
	}
	
	[MessagePackObject]
	[Union(0, typeof(LoadDataRes))]
	[Union(1, typeof(GetRankRes))]
	[Union(2, typeof(SetRankRes))]
	public abstract class ProtocolRes
	{
		[Key(0)] public ProtocolId ProtocolId { get; set; }

		public ProtocolRes() {}
		public ProtocolRes(ProtocolId protocolId) { ProtocolId = protocolId; }
	}
}
