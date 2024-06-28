using System.Data;
using HttpServer.Cache;
using Dapper;
using HttpServer.Pages.DBCompareTool;
using MySqlConnector;

namespace Common
{
    public partial class GameDB
    {
        public static async Task SetDashBoardMemberAsync(DashBoardMember dashBoardMember)
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                await SpSetDashBoardMemberAsync(conn, null, dashBoardMember);
            }
        }

        private static async Task SpSetDashBoardMemberAsync(MySqlConnection conn, MySqlTransaction trxn, DashBoardMember dashBoardMember)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_dashBoardSeq", dashBoardMember.DashBoardSeq);
            parameters.Add("_puuid", dashBoardMember.Puuid);
            parameters.Add("_name", dashBoardMember.Name);
            parameters.Add("_enable", dashBoardMember.Enable);
            parameters.Add("_supWinCount", dashBoardMember.SupWinCount);
            parameters.Add("_supLoseCount", dashBoardMember.SupLoseCount);
            parameters.Add("_adcWinCount", dashBoardMember.AdcWinCount);
            parameters.Add("_adcLoseCount", dashBoardMember.AdcLoseCount);
            parameters.Add("_midWinCount", dashBoardMember.MidWinCount);
            parameters.Add("_midLoseCount", dashBoardMember.MidLoseCount);
            parameters.Add("_jgWinCount", dashBoardMember.JgWinCount);
            parameters.Add("_jgLoseCount", dashBoardMember.JgLoseCount);
            parameters.Add("_topWinCount", dashBoardMember.TopWinCount);
            parameters.Add("_topLoseCount", dashBoardMember.TopLoseCount);
            

            await conn.ExecuteAsync("spSetDashBoardMember", parameters, trxn, commandType: CommandType.StoredProcedure);
        }
    }
}