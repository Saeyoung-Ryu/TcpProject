using System.Data;
using Common.Redis;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task<Player?> GetPlayerWithEmailAsync(string email, bool needToCache = false)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                var player = await SpGetPlayerWithEmailAsync(conn, null, email);
                
                if (needToCache && player != null && !await RedisService.KeyExists(player.Suid.ToString()))
                    await RedisService.SetKeyValueAsync(player.Suid.ToString(), player);

                return player;
            }
        }

        private static async Task<Player?> SpGetPlayerWithEmailAsync(MySqlConnection conn, MySqlTransaction trxn, string email)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_email", email);

            return await conn.QuerySingleOrDefaultAsync<Player>("spGetPlayerWithEmail", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}