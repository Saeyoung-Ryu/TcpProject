using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class RankDB
    {
        public static async Task<List<Rank>> GetRankListAsync()
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetRankListAsync(conn, null);
            }
        }

        private static async Task<List<Rank>> SpGetRankListAsync(MySqlConnection conn, MySqlTransaction trxn)
        {
            var parameters = new DynamicParameters();

            return (await conn.QueryAsync<Rank>("spGetRankList", parameters, trxn, commandType: CommandType.StoredProcedure)).ToList();
        }
    }
}