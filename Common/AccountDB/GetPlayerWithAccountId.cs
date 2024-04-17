using System.Data;
using Common.Redis;
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
                var player = await SpGetPlayerWithAccountIdAsync(conn, null, accountId, loginType);
                
                if (!await RedisService.KeyExists(player.Suid.ToString()))
                    await RedisService.SetKeyValueAsync(player.Suid.ToString(), player);

                return player;
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