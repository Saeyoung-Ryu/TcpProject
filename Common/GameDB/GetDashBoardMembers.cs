using System.Data;
using HttpServer.Cache;
using Dapper;
using HttpServer.Pages.DBCompareTool;
using MySqlConnector;

namespace Common
{
    public partial class GameDB
    {
        public static async Task<List<DashBoardMember>> GetDashBoardMembersAsync(int dashBoardSeq)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetDashBoardMembersAsync(conn, null, dashBoardSeq);
            }
        }

        private static async Task<List<DashBoardMember>> SpGetDashBoardMembersAsync(MySqlConnection conn, MySqlTransaction trxn, int dashBoardSeq)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_dashBoardSeq", dashBoardSeq);

            return (await conn.QueryAsync<DashBoardMember>("spGetDashBoardMembers", parameters, trxn, commandType: CommandType.StoredProcedure)).ToList();
        }
    }
}