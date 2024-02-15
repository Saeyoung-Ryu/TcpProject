using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class RankDB
    {
        public static async Task<Rank?> GetRankAsync(long playerSeq)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetRankAsync(conn, null, playerSeq);
            }
        }

        private static async Task<Rank?> SpGetRankAsync(MySqlConnection conn, MySqlTransaction trxn, long playerSeq)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_playerSeq", playerSeq);

            return await conn.QuerySingleOrDefaultAsync<Rank>("spGetRank", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}