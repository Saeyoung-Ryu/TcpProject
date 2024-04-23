
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class TblAttendanceReward
{
    public int AttendanceRewardId { get; private set; }
    public int ItemId { get; private set; }
    public int Count { get; private set; }
    
    public static Dictionary<int, TblAttendanceReward> Dictionary = new Dictionary<int, TblAttendanceReward>();
    public static List<TblAttendanceReward> ListAll = new List<TblAttendanceReward>();
    
    public static async Task RefreshAsync()
    {
        try
        {
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                Dictionary.Clear();
                ListAll.Clear();
                
                string sql = "select * from tblAttendanceReward";

                var list = await connection.QueryAsync<TblAttendanceReward>(sql);

                foreach (var item in list)
                {
                    Dictionary.Add(item.AttendanceRewardId, item);
                    ListAll.Add(item);
                }
            }
            
            MyLogger.WriteLineInfo("TblAttendanceReward Refresh Success");
        }
        catch (Exception)
        {
            MyLogger.WriteLineError("TblAttendanceReward Refresh Error");
        }
        
    }
}