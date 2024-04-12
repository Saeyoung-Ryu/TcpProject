using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task<Player?> GetPlayerWithSuidAsync(long suid)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetPlayerWithSuidAsync(conn, null, suid);
            }
        }

        private static async Task<Player?> SpGetPlayerWithSuidAsync(MySqlConnection conn, MySqlTransaction trxn, long suid)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_suid", suid);

            return await conn.QuerySingleOrDefaultAsync<Player>("spGetPlayerWithSuid", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}