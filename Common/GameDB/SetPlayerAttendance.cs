using System.Data;
using HttpServer.Cache;
using Dapper;
using HttpServer.Pages.DBCompareTool;
using MySqlConnector;

namespace Common
{
    public partial class GameDB
    {
        public static async Task SetPlayerAttendanceAsync(PlayerAttendance playerAttendance)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                await SpSetPlayerAttendance(conn, null, playerAttendance);
            }
        }

        private static async Task SpSetPlayerAttendance(MySqlConnection conn, MySqlTransaction trxn, PlayerAttendance playerAttendance)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_suid", playerAttendance.Suid);
            parameters.Add("_attendanceBasicId", playerAttendance.AttendanceBasicId);
            parameters.Add("_day", playerAttendance.Day);
            parameters.Add("_updateTime", playerAttendance.UpdateTime);

            await conn.ExecuteAsync("spSetPlayerAttendance", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}