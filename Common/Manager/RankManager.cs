using MyUtil;

namespace Common;

public class RankManager
{
    public static List<Rank> playerRankList = new List<Rank>();

    public static async Task RefreshRankAsync()
    {
        var rankList = await RankDB.GetRankListAsync();

        playerRankList = rankList.OrderByDescending(e => e.Point).ToList();

        MyLogger.WriteLineInfo("Rank Refresh Success");
    }
    
    public static int GetMyRank(long suid)
    {
        var myRank = new Rank();

        int ranking = 1;
        foreach (var playerRank in playerRankList)
        {
            if (playerRank.Suid == suid)
                break;

            ranking++;
        }

        return ranking;
    }
    
    public static async Task SetPlayerWinLoseAsync(Player winnerPlayer, Player loserPlayer)
    {
        var winnerPlayerRank = GetRank(winnerPlayer.Suid).Rank;
        var loserPlayerRank = GetRank(loserPlayer.Suid).Rank;
        
        winnerPlayerRank.WinCount++;
        winnerPlayerRank.Point = CalculatePoint(winnerPlayerRank.WinCount, winnerPlayerRank.LoseCount);
        
        loserPlayerRank.LoseCount++;
        loserPlayerRank.Point = CalculatePoint(loserPlayerRank.WinCount, loserPlayerRank.LoseCount);

        // Db update
        await RankDB.SetRankAsync(winnerPlayerRank);
        await RankDB.SetRankAsync(loserPlayerRank);
        
        // RankList Memory update
        UpdateRankList(winnerPlayerRank);
        UpdateRankList(loserPlayerRank);
        
        // Update MatchHistory
        await MatchHistoryManager.SetMatchHistoryAsync(winnerPlayer, loserPlayer);
    }
    
    public static (Rank Rank, int Ranking) GetRank(long suid)
    {
        var rank = FindRankFromList(suid);

        if (rank.Rank == null)
        {
            return (new Rank()
            {
                Suid = suid,
                WinCount = 0,
                LoseCount = 0,
                Point = 100, // default 100
            }, 0);
        }

        return (rank.Rank, rank.Ranking);
    }

    private static (Rank? Rank, int Ranking) FindRankFromList(long suid)
    {
        int ranking = 0;
        
        foreach (var playerRank in playerRankList)
        {
            ranking++;
            
            if (playerRank.Suid == suid)
                return (playerRank, ranking);
        }

        return (null, 0);
    }
    
    public static int CalculatePoint(int winCount, int loseCount)
    {
        // 1승하면 +5점, 1패하면 -4점, point는 0점 이상
        int totalPoint = 100 + winCount * 5 - loseCount * 4;
        
        if (totalPoint < 0)
            totalPoint = 0;
        
        return totalPoint;
    }
    
    public static void UpdateRankList(Rank playerRank)
    {
        bool isUpdated = false;
        
        foreach (var item in playerRankList)
        {
            if (item.Suid == playerRank.Suid)
            {
                item.WinCount = playerRank.WinCount;
                item.LoseCount = playerRank.LoseCount;
                item.Point = playerRank.Point;

                isUpdated = true;
                break;
            }
        }
        
        if (!isUpdated)
            playerRankList.Add(playerRank);

        playerRankList = playerRankList.OrderByDescending(e => e.Point).ToList();
    }
}