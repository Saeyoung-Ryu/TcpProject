
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class TblServerVariable
{
    public bigint Seq { get; private set; }
    public string Name { get; private set; }
    public string Value { get; private set; }
    
    public static Dictionary<int, TblServerVariable> Dictionary = new Dictionary<int, TblServerVariable>();
    public static List<TblServerVariable> ListAll = new List<TblServerVariable>();
    
    public static async Task RefreshAsync()
    {
        try
        {
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                string sql = "select * from tblServerVariable";

                var list = await connection.QueryAsync<TblServerVariable>(sql);

                foreach (var item in list)
                {
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }
            }
            
            MyLogger.WriteLineInfo("TblServerVariable Refresh Success");
        }
        catch (Exception)
        {
            MyLogger.WriteLineError("TblServerVariable Refresh Error");
        }
        
    }
}