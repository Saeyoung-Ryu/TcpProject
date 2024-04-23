
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class TblMatchHistory
{
    public bigint Seq { get; private set; }
    public bigint Suid { get; private set; }
    public string Data { get; private set; }
    
    public static Dictionary<int, TblMatchHistory> Dictionary = new Dictionary<int, TblMatchHistory>();
    public static List<TblMatchHistory> ListAll = new List<TblMatchHistory>();
    
    public static async Task RefreshAsync()
    {
        try
        {
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                string sql = "select * from tblMatchHistory";

                var list = await connection.QueryAsync<TblMatchHistory>(sql);

                foreach (var item in list)
                {
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }
            }
            
            MyLogger.WriteLineInfo("TblMatchHistory Refresh Success");
        }
        catch (Exception)
        {
            MyLogger.WriteLineError("TblMatchHistory Refresh Error");
        }
        
    }
}