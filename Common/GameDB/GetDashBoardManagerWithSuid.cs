using System.Data;
using HttpServer.Cache;
using Dapper;
using HttpServer.Pages.DBCompareTool;
using MySqlConnector;

namespace Common
{
    public partial class GameDB
    {
        public static async Task<List<DashBoardManager>> GetDashBoardManagerWithSuidAsync(long suid)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetDashBoardManagerWithSuidAsync(conn, null, suid);
            }
        }

        private static async Task<List<DashBoardManager>> SpGetDashBoardManagerWithSuidAsync(MySqlConnection conn, MySqlTransaction trxn, long suid)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_suid", suid);

            return (await conn.QueryAsync<DashBoardManager>("SpGetDashBoardManagerWithSuid", parameters, trxn, commandType: CommandType.StoredProcedure)).ToList();
        }
    }
}