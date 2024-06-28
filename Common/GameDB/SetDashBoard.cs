using System.Data;
using HttpServer.Cache;
using Dapper;
using HttpServer.Pages.DBCompareTool;
using MySqlConnector;

namespace Common
{
    public partial class GameDB
    {
        public static async Task SetDashBoardAsync(DashBoard dashBoard)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                await SpSetDashBoardAsync(conn, null, dashBoard);
            }
        }

        private static async Task SpSetDashBoardAsync(MySqlConnection conn, MySqlTransaction trxn, DashBoard dashBoard)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_name", dashBoard.Name);

            await conn.ExecuteAsync("spSetDashBoard", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}