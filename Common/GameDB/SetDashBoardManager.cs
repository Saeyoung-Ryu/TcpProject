using System.Data;
using HttpServer.Cache;
using Dapper;
using HttpServer.Pages.DBCompareTool;
using MySqlConnector;

namespace Common
{
    public partial class GameDB
    {
        public static async Task SetDashBoardManagerAsync(DashBoardManager dashBoardManager)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                await SpSetDashBoardManagerAsync(conn, null, dashBoardManager);
            }
        }

        private static async Task SpSetDashBoardManagerAsync(MySqlConnection conn, MySqlTransaction trxn, DashBoardManager dashBoardManager)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_name", dashBoardManager.Suid);
            parameters.Add("_dashBoardSeq", dashBoardManager.DashBoardSeq);
            parameters.Add("position", (int) dashBoardManager.Position);
            parameters.Add("_enable", dashBoardManager.Enable);

            await conn.ExecuteAsync("spSetDashBoardManager", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}