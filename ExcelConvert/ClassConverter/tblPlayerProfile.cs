
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class TblPlayerProfile
{
    public bigint Suid { get; private set; }
    public bigint Cash { get; private set; }
    
    public static Dictionary<int, TblPlayerProfile> Dictionary = new Dictionary<int, TblPlayerProfile>();
    public static List<TblPlayerProfile> ListAll = new List<TblPlayerProfile>();
    
    public static async Task RefreshAsync()
    {
        try
        {
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                string sql = "select * from tblPlayerProfile";

                var list = await connection.QueryAsync<TblPlayerProfile>(sql);

                foreach (var item in list)
                {
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }
            }
            
            MyLogger.WriteLineInfo("TblPlayerProfile Refresh Success");
        }
        catch (Exception)
        {
            MyLogger.WriteLineError("TblPlayerProfile Refresh Error");
        }
        
    }
}