using System.Data;
using HttpServer.Cache;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task<Player?> GetPlayerWithNicknameAsync(string nickName, bool needToCache = false)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                var player = await SpGetPlayerWithNicknameAsync(conn, null, nickName);
                
                if (needToCache && player != null && !await RedisService.KeyExists(player.Suid.ToString()))
                    await RedisService.SetKeyValueAsync(player.Suid.ToString(), player);

                return player;
            }
        }

        private static async Task<Player?> SpGetPlayerWithNicknameAsync(MySqlConnection conn, MySqlTransaction trxn, string nickName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_nickname", nickName);

            return await conn.QuerySingleOrDefaultAsync<Player>("spGetPlayerWithNickname", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}