using System.Data;
using HttpServer.Cache;
using Dapper;
using HttpServer.Pages.DBCompareTool;
using MySqlConnector;

namespace Common
{
    public partial class GameDB
    {
        public static async Task<DashBoard?> GetDashBoardWithNameAsync(string name)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetDashBoardWithNameAsync(conn, null, name);
            }
        }

        private static async Task<DashBoard?> SpGetDashBoardWithNameAsync(MySqlConnection conn, MySqlTransaction trxn, string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_name", name);

            return await conn.QuerySingleOrDefaultAsync<DashBoard>("spGetDashBoardWithName", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}