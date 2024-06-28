using System.Data;
using HttpServer.Cache;
using Dapper;
using HttpServer.Pages.DBCompareTool;
using MySqlConnector;

namespace Common
{
    public partial class GameDB
    {
        public static async Task<DashBoard> GetDashBoardWithSeqAsync(int seq)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetDashBoardWithSeqAsync(conn, null, seq);
            }
        }

        private static async Task<DashBoard> SpGetDashBoardWithSeqAsync(MySqlConnection conn, MySqlTransaction trxn, int seq)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_seq", seq);

            return await conn.QuerySingleOrDefaultAsync<DashBoard>("spGetDashBoardWithSeq", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}