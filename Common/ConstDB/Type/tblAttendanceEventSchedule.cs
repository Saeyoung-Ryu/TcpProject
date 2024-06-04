
using Dapper;
using MySqlConnector;
using MyUtil;

namespace Common.ConstDB.Type;

[Refreshable]
public class TblAttendanceEventSchedule
{
    public int AttendanceBasicId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public sbyte Enable { get; private set; }
    
    public static Dictionary<int, TblAttendanceEventSchedule> Dictionary = new Dictionary<int, TblAttendanceEventSchedule>();
    public static List<TblAttendanceEventSchedule> ListAll = new List<TblAttendanceEventSchedule>();
    
    public static async Task RefreshAsync()
    {
        try
        {
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                Dictionary.Clear();
                ListAll.Clear();
                
                string sql = "select * from tblAttendanceEventSchedule";

                var list = await connection.QueryAsync<TblAttendanceEventSchedule>(sql);

                foreach (var item in list)
                {
                    Dictionary.Add(item.AttendanceBasicId, item);
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
    
    public static TblAttendanceEventSchedule? GetCurrentEventSchedule(DateTime now)
    {
        return ListAll.FirstOrDefault(x => x.StartDate.CompareTo(now) <= 0 && x.EndDate.CompareTo(now) >= 0);
    }
}