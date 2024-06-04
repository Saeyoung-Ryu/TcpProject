using MessagePack;

namespace Common;

[MessagePackObject]
public class PlayerAttendance
{
    [Key(0)] public long Suid { get; set; }
    [Key(1)] public int AttendanceBasicId { get; set; }
    [Key(2)] public int Day { get; set; }
    [Key(3)] public DateTime UpdateTime { get; set; }
}