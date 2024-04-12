using System.Data;
using Dapper;
using Enum;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task<Player?> GetPlayerWithAccountIdAsync(string accountId, LoginType loginType)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetPlayerWithAccountIdAsync(conn, null, accountId, loginType);
            }
        }

        private static async Task<Player?> SpGetPlayerWithAccountIdAsync(MySqlConnection conn, MySqlTransaction trxn, string accountId, LoginType loginType)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_accountId", accountId);
            parameters.Add("_loginType", loginType);

            return await conn.QuerySingleOrDefaultAsync<Player>("spGetPlayerWithAccountId", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}