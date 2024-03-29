using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task<Player?> GetPlayerWithSeqAsync(long seq)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetPlayerWithSeqAsync(conn, null, seq);
            }
        }

        private static async Task<Player?> SpGetPlayerWithSeqAsync(MySqlConnection conn, MySqlTransaction trxn, long seq)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_seq", seq);

            return await conn.QuerySingleOrDefaultAsync<Player>("spGetPlayerWithSeq", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}