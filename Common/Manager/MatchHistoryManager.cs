namespace Common;

public class MatchHistoryManager
{
    public static async Task SetMatchHistoryAsync(long winnerSeq, long loserSeq)
    {
        var winnerMatchHistory = await GetAsync(winnerSeq);
        var loserMatchHistory = await GetAsync(loserSeq);
        
        
    }

    private static async Task<MatchHistory> GetAsync(long playerSeq)
    {
        var matchHistory = await LogDB.GetMatchHistoryAsync(playerSeq);

        if (matchHistory == null)
        {
            matchHistory = new MatchHistory()
            {
                PlayerSeq = playerSeq,
                Data = String.Empty
            };
        }

        return matchHistory;
    }

    // private static string GetUpdatedData(MatchHistory matchHistory, string dataToAdd)
    // {
    //     
    // }
}