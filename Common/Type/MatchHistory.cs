using Newtonsoft.Json;

namespace Common;

public class MatchHistory
{
    public long PlayerSeq { get; set; }
    public string Data { get; set; } // json Key : WinLose, Value : OpponentNickName
    
    /*public string ToRewards(Dictionary<int, RpsWinRewardState> dictionary)
    {
        return JsonConvert.SerializeObject(dictionary);
    }

    public Dictionary<int, RpsWinRewardState> FromRewards() 
    {
        if (string.IsNullOrEmpty(Rewards))
            return new Dictionary<int, RpsWinRewardState>();
			
        return JsonConvert.DeserializeObject<Dictionary<int, RpsWinRewardState>>(Rewards);
    }*/
}