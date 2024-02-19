using Enum;

namespace Common;

public class MatchHistoryManager
{
    public static async Task SetMatchHistoryAsync(Player winnerPlayer, Player loserPlayer)
    {
        var (winnerMatchHistory, winnerNickname) = await GetAsync(winnerPlayer);
        var (loserMatchHistory, loserNickname) = await GetAsync(loserPlayer);
        
        if (winnerMatchHistory == null || loserMatchHistory == null)
            return;

        Dictionary<WinLoseType, string> dictionaryToAdd = new Dictionary<WinLoseType, string>();
        
        dictionaryToAdd.Add(WinLoseType.Win, winnerNickname);
        dictionaryToAdd.Add(WinLoseType.Lose, loserNickname);
        
        await SetWinLoseHistoryAsync(new MatchHistory[] {winnerMatchHistory, loserMatchHistory}, dictionaryToAdd);
    }

    public static async Task<(MatchHistory? MatchHistory, string Nickname)> GetAsync(Player player)
    {
        var matchHistory = await LogDB.GetMatchHistoryAsync(player.Seq);

        if (matchHistory == null)
        {
            matchHistory = new MatchHistory()
            {
                PlayerSeq = player.Seq,
                Data = string.Empty
            };
        }

        return (matchHistory, player.Nickname);
    }

    private static async Task SetWinLoseHistoryAsync(MatchHistory[] matchHistories, Dictionary<WinLoseType, string> dictionaryToAdd)
    {
        foreach (var matchHistory in matchHistories)
        {
            var dataDic = matchHistory.FromData();
            
            if (dataDic.Count < 10)
                dataDic.Add(dictionaryToAdd);
            else
            {
                dataDic.Remove(dataDic.First());
                dataDic.Add(dictionaryToAdd);
            }

            matchHistory.Data = matchHistory.ToData(dataDic);

            await LogDB.SetMatchHistoryAsync(matchHistory);
        }
    }
}