using System.Data;
using Common.Redis;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task<Player?> GetPlayerWithSeqAsync(long seq, bool needToCache = false)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                var player = await SpGetPlayerWithSeqAsync(conn, null, seq);
                
                if (needToCache && player != null && !await RedisService.KeyExists(player.Suid.ToString()))
                    await RedisService.SetKeyValueAsync(player.Suid.ToString(), player);

                return player;
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