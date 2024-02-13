using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task<Player?> GetPlayerAsync(string nickName)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetPlayerAsync(conn, null, nickName);
            }
        }

        private static async Task<Player?> SpGetPlayerAsync(MySqlConnection conn, MySqlTransaction trxn, string nickName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_nickname", nickName);

            return await conn.QuerySingleOrDefaultAsync<Player>("spGetPlayer", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}