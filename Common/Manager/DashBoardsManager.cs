using Common.ConstDB.Type;
using Enum;
using HttpServer;

namespace Common;

public class DashBoardsManager
{
    public static async Task<List<string>> GetManagingDashBoardNamesAsync(long suid)
    {
        var dashBoards = await GameDB.GetDashBoardManagerWithSuidAsync(suid);
        var dashBoardSeqList = dashBoards.Select(e => e.DashBoardSeq).ToList();

        List<string> managingDashBoardNames = new List<string>();
                
        foreach (var dashBoardSeq in dashBoardSeqList)
        {
            var dashBoardInfo = await GameDB.GetDashBoardWithSeqAsync(dashBoardSeq);
                    
            managingDashBoardNames.Add(dashBoardInfo.Name);
        }

        return managingDashBoardNames;
    }
}