using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task<Player?> GetPlayerWithNicknameAsync(string nickName)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                return await SpGetPlayerWithNicknameAsync(conn, null, nickName);
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