
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class TblAttendanceEventSchedule
{
    public int AttendanceBasicId { get; private set; }
    public string StartDate { get; private set; }
    public string EndDate { get; private set; }
    public string Enable { get; private set; }
    
    public static Dictionary<int, TblAttendanceEventSchedule> Dictionary = new Dictionary<int, TblAttendanceEventSchedule>();
    public static List<TblAttendanceEventSchedule> ListAll = new List<TblAttendanceEventSchedule>();
    
    public static async Task RefreshAsync()
    {
        try
        {
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                string sql = "select * from tblAttendanceEventSchedule";

                var list = await connection.QueryAsync<TblAttendanceEventSchedule>(sql);

                foreach (var item in list)
                {
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }
            }
            
            MyLogger.WriteLineInfo("TblAttendanceEventSchedule Refresh Success");
        }
        catch (Exception)
        {
            MyLogger.WriteLineError("TblAttendanceEventSchedule Refresh Error");
        }
        
    }
}