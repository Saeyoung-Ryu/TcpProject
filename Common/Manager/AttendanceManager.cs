using Common.ConstDB.Type;
using Enum;
using HttpServer;

namespace Common;

public class AttendanceManager
{
    public static async Task<PlayerAttendance> GetPlayerAttendanceAsync(Player player)
    {
        DateTime now = DateTime.UtcNow;
        var currentAttendanceEventSchedule = TblAttendanceEventSchedule.GetCurrentEventSchedule(now);
        
        if (currentAttendanceEventSchedule == null)
            return null;

        var tblAttendanceBasic = TblAttendanceBasic.Find(currentAttendanceEventSchedule.AttendanceBasicId);
        
        if (tblAttendanceBasic == null)
            return null;
        
        var playerAttendance = await GameDB.GetPlayerAttendanceAsync(player.Suid);

        playerAttendance ??= new PlayerAttendance
        {
            Suid = player.Suid,
            AttendanceBasicId = currentAttendanceEventSchedule.AttendanceBasicId,
            Day = 1,
            UpdateTime = DateTime.UtcNow
        };

        if (playerAttendance.UpdateTime.Date != now.Date && playerAttendance.Day < tblAttendanceBasic.Days)
        {
            playerAttendance.Day++;
            playerAttendance.UpdateTime = now;
        }
        
        await GameDB.SetPlayerAttendanceAsync(playerAttendance);
        
        return playerAttendance;
    }
}