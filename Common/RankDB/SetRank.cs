using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class RankDB
    {
        public static async Task SetRankAsync(Rank rank)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                await SpSetRankAsync(conn, null, rank);
            }
        }

        private static async Task SpSetRankAsync(MySqlConnection conn, MySqlTransaction trxn, Rank rank)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_suid", rank.Suid);
            parameters.Add("_winCount", rank.WinCount);
            parameters.Add("_loseCount", rank.LoseCount);
            parameters.Add("_point", rank.Point);

            await conn.ExecuteAsync("spSetRank", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}