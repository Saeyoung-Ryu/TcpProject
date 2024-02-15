using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task InsertPlayerAsync(string nickName)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                await SpInsertPlayerAsync(conn, null, nickName);
            }
        }

        private static async Task SpInsertPlayerAsync(MySqlConnection conn, MySqlTransaction trxn, string nickName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_nickname", nickName);
            parameters.Add("_createTime", DateTime.UtcNow);

            await conn.ExecuteAsync("spInsertPlayer", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}