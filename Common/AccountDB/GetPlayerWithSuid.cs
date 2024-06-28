using System.Data;
using HttpServer.Cache;
using Dapper;
using HttpServer.Pages.DBCompareTool;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task<Player?> GetPlayerWithSuidAsync(long suid)
        {
            var player = await RedisService.GetValueAsync<Player?>(suid.ToString());

            if (player != null)
                return player;
            
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                player =  await SpGetPlayerWithSuidAsync(conn, null, suid);
                await RedisService.SetKeyValueAsync(suid.ToString(), player);
                return player;
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