using System.Data;
using HttpServer.Cache;
using Dapper;
using HttpServer.Pages.DBCompareTool;
using MySqlConnector;

namespace Common
{
    public partial class GameDB
    {
        public static async Task<List<DashBoardManager>> GetDashBoardManagerWithDashBoardSeqAsync(int seq)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetDashBoardManagerWithDashBoardSeqAsync(conn, null, seq);
            }
        }

        private static async Task<List<DashBoardManager>> SpGetDashBoardManagerWithDashBoardSeqAsync(MySqlConnection conn, MySqlTransaction trxn, int seq)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_dashBoardSeq", seq);

            return (await conn.QueryAsync<DashBoardManager>("SpGetDashBoardManagerWithDashBoardSeq", parameters, trxn, commandType: CommandType.StoredProcedure)).ToList();
        }
    }
}