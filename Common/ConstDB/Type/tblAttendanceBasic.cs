using Dapper;
using MySqlConnector;

namespace Common.ConstDB.Type;

[Refreshable]
public class tblAttendanceBasic
{
    public int BasicId { get; private set; }
    public int Day { get; private set; }
    public int RewardId { get; private set; }

    public static Dictionary<int, tblAttendanceBasic> Dictionary = new Dictionary<int, tblAttendanceBasic>();
    public static List<tblAttendanceBasic> ListAll = new List<tblAttendanceBasic>();
    
    public static async Task RefreshAsync()
    {
        try
        {
            await using (var connection = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                string sql = "select * from tblAttendanceBasic";

                var list = await connection.QueryAsync<tblAttendanceBasic>(sql);

                foreach (var item in list)
                {
                    Dictionary.Add(item.BasicId, item);
                    ListAll.Add(item);
                }
            }
            
            Console.WriteLine("tblAttendanceBasic Refresh Success");
        }
        catch (Exception)
        {
            Console.WriteLine("tblAttendanceBasic Refresh Error");
        }
        
    }
}