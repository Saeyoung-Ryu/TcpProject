using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class RankDB
    {
        public static async Task<Player?> GetPlayerWithSeq2Async(long seq)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetPlayerWithSeqAsync(conn, null, seq);
            }
        }

        private static async Task<Player?> SpGetPlayerWithSeq2Async(MySqlConnection conn, MySqlTransaction trxn, long seq)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_seq", seq);

            return await conn.QuerySingleOrDefaultAsync<Player>("spGetPlayerWithSeq", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}