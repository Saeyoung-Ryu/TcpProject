using System.Data;
using HttpServer.Cache;
using Dapper;
using HttpServer.Pages.DBCompareTool;
using MySqlConnector;

namespace Common
{
    public partial class GameDB
    {
        public static async Task<PlayerAttendance?> GetPlayerAttendanceAsync(long suid)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetPlayerAttendance(conn, null, suid);
            }
        }

        private static async Task<PlayerAttendance?> SpGetPlayerAttendance(MySqlConnection conn, MySqlTransaction trxn, long suid)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_suid", suid);

            return await conn.QuerySingleOrDefaultAsync<PlayerAttendance>("spGetPlayerAttendance", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}