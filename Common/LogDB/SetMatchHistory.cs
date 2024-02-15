using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class LogDB
    {
        public static async Task SetMatchHistoryAsync(MatchHistory matchHistory)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                await SpSetMatchHistoryAsync(conn, null, matchHistory);
            }
        }

        private static async Task SpSetMatchHistoryAsync(MySqlConnection conn, MySqlTransaction trxn, MatchHistory matchHistory)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_playerSeq", matchHistory.PlayerSeq);
            parameters.Add("_data", matchHistory.Data);

            await conn.ExecuteAsync("spSetMatchHistory", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}