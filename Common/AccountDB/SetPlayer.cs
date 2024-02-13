using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task SetPlayerAsync(string nickName)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                await SpSetPlayerAsync(conn, null, nickName);
            }
        }

        private static async Task SpSetPlayerAsync(MySqlConnection conn, MySqlTransaction trxn, string nickName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_nickname", nickName);
            parameters.Add("_createTime", DateTime.UtcNow);

            await conn.ExecuteAsync("spSetPlayer", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}