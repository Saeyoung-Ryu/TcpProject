
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class TblAttendanceBasic
{
    public int BasicId { get; private set; }
    public int Days { get; private set; }
    public int RewardId { get; private set; }
    
    public static Dictionary<int, TblAttendanceBasic> Dictionary = new Dictionary<int, TblAttendanceBasic>();
    public static List<TblAttendanceBasic> ListAll = new List<TblAttendanceBasic>();
    
    public static async Task RefreshAsync()
    {
        try
        {
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                string sql = "select * from tblAttendanceBasic";

                var list = await connection.QueryAsync<TblAttendanceBasic>(sql);

                foreach (var item in list)
                {
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }
            }
            
            MyLogger.WriteLineInfo("TblAttendanceBasic Refresh Success");
        }
        catch (Exception)
        {
            MyLogger.WriteLineError("TblAttendanceBasic Refresh Error");
        }
        
    }
}