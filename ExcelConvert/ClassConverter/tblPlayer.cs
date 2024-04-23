
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class TblPlayer
{
    public bigint Seq { get; private set; }
    public bigint Suid { get; private set; }
    public string AccountId { get; private set; }
    public int LoginType { get; private set; }
    public string NickName { get; private set; }
    public datetime CreateTime { get; private set; }
    
    public static Dictionary<int, TblPlayer> Dictionary = new Dictionary<int, TblPlayer>();
    public static List<TblPlayer> ListAll = new List<TblPlayer>();
    
    public static async Task RefreshAsync()
    {
        try
        {
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                string sql = "select * from tblPlayer";

                var list = await connection.QueryAsync<TblPlayer>(sql);

                foreach (var item in list)
                {
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }
            }
            
            MyLogger.WriteLineInfo("TblPlayer Refresh Success");
        }
        catch (Exception)
        {
            MyLogger.WriteLineError("TblPlayer Refresh Error");
        }
        
    }
}