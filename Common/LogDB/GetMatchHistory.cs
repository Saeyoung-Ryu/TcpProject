using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class LogDB
    {
        public static async Task<MatchHistory?> GetMatchHistoryAsync(long playerSeq)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetMatchHistoryAsync(conn, null, playerSeq);
            }
        }

        private static async Task<MatchHistory?> SpGetMatchHistoryAsync(MySqlConnection conn, MySqlTransaction trxn, long playerSeq)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_playerSeq", playerSeq);

            return await conn.QuerySingleOrDefaultAsync<MatchHistory>("spGetMatchHistory", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}