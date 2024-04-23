
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class TblRank
{
    public bigint Seq { get; private set; }
    public bigint Suid { get; private set; }
    public int WinCount { get; private set; }
    public int LoseCount { get; private set; }
    public int Point { get; private set; }
    
    public static Dictionary<int, TblRank> Dictionary = new Dictionary<int, TblRank>();
    public static List<TblRank> ListAll = new List<TblRank>();
    
    public static async Task RefreshAsync()
    {
        try
        {
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                string sql = "select * from tblRank";

                var list = await connection.QueryAsync<TblRank>(sql);

                foreach (var item in list)
                {
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }
            }
            
            MyLogger.WriteLineInfo("TblRank Refresh Success");
        }
        catch (Exception)
        {
            MyLogger.WriteLineError("TblRank Refresh Error");
        }
        
    }
}