namespace Common;

public class RankManager
{
    public static SortedList<int, Rank> sortedRankList = new SortedList<int, Rank>();

    public static async Task RefreshRankAsync()
    {
        var rankList = await RankDB.GetRankListAsync();

        foreach (var rank in rankList)
        {
            sortedRankList.Add(rank.Point, rank);
        }

        Console.WriteLine("Rank Refresh Success");
    }

    public static Rank GetMyRank(long playerSeq)
    {
        var myRank = new Rank();

        int ranking = 1;
        foreach (var rank in sortedRankList.Values)
        {
            if (rank.PlayerSeq == playerSeq)
            {
                myRank = rank;
                myRank.Ranking = ranking;
                break;
            }

            ranking++;
        }

        return myRank;
    }

    public static async Task SetPlayerWinLoseAsync(long winnerPlayerSeq, long loserPlayerSeq)
    {
        var winnerPlayerRank = await GetRankAsync(winnerPlayerSeq);
        var loserPlayerRank = await GetRankAsync(loserPlayerSeq);
        
        winnerPlayerRank.WinCount++;
        winnerPlayerRank.Point = CalculatePoint(winnerPlayerRank.WinCount, winnerPlayerRank.LoseCount);
        
        loserPlayerRank.LoseCount++;
        loserPlayerRank.Point = CalculatePoint(loserPlayerRank.WinCount, loserPlayerRank.LoseCount);

        // Db update
        await RankDB.SetRankAsync(winnerPlayerRank);
        await RankDB.SetRankAsync(loserPlayerRank);
        
        // SortedList Memory update
        UpdateSortedRankList(winnerPlayerRank);
        UpdateSortedRankList(loserPlayerRank);
    }

    private static async Task<Rank> GetRankAsync(long playerSeq)
    {
        var rank = await RankDB.GetRankAsync(playerSeq);

        Rank initRank = new Rank()
        {
            PlayerSeq = playerSeq,
            WinCount = 0,
            LoseCount = 0,
            Point = 100, // default 100
        };

        if (rank == null)
        {
            await RankDB.SetRankAsync(initRank);
            rank = initRank;
        }

        return rank;
    }

    private static int CalculatePoint(int winCount, int loseCount)
    {
        // 1승하면 +5점, 1패하면 -4점, point는 0점 이상
        int totalPoint = 100 + winCount * 5 - loseCount * 4;
        
        if (totalPoint < 0)
            totalPoint = 0;
        
        return totalPoint;
    }
    
    private static void UpdateSortedRankList(Rank playerRank)
    {
        if (sortedRankList.ContainsKey(playerRank.Point))
            sortedRankList.Remove(playerRank.Point);
        
        sortedRankList.Add(playerRank.Point, playerRank);
    }
}