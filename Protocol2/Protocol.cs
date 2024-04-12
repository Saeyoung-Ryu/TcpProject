using Enum;
using MessagePack;

namespace Protocol2
{
	public enum ProtocolId
	{
		None = 0,
		LoadData = 1,
		GetRank = 2,
		SetRank = 3,
		EditNickname = 4,
		GetMatchHistory = 5,
	}
	
	[MessagePackObject]
	[Union(0, typeof(LoadDataReq))]
	[Union(1, typeof(GetRankReq))]
	[Union(2, typeof(SetRankReq))]
	[Union(3, typeof(EditNicknameReq))]
	[Union(4, typeof(GetMatchHistoryReq))]
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
	[Union(3, typeof(EditNicknameRes))]
	[Union(4, typeof(GetMatchHistoryRes))]
	public abstract class ProtocolRes
	{
		[Key(0)] public ProtocolId ProtocolId { get; set; }
		[Key(1)] public Result Result { get; set; }

		public ProtocolRes() {}
		public ProtocolRes(ProtocolId protocolId) { ProtocolId = protocolId; }
	}
}
