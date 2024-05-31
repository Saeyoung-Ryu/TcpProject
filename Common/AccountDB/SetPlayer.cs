using System.Data;
using Dapper;
using MySqlConnector;

namespace Common
{
    public partial class AccountDB
    {
        public static async Task SetPlayerAsync(Player player)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                await SpSetPlayerAsync(conn, null, player);
            }
        }

        private static async Task SpSetPlayerAsync(MySqlConnection conn, MySqlTransaction trxn, Player player)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_suid", player.Suid);
            parameters.Add("_accountId", player.AccountId);
            parameters.Add("_loginType", player.LoginType);
            parameters.Add("_nickname", player.Nickname);
            parameters.Add("_email", player.Email);
            parameters.Add("_password", player.Password);
            parameters.Add("_passwordSalt", player.PasswordSalt);
            parameters.Add("_createTime", player.CreateTime);

            await conn.ExecuteAsync("spSetPlayer", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}