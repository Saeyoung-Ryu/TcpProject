using Enum;
using Newtonsoft.Json;

namespace Common;

public class MatchHistory
{
    public long PlayerSeq { get; set; }
    public string Data { get; set; } // {{"1":"amy","2":"samy"},{"1":"amy2","2":"samy"},{"1":"amy4","2":"samy"}}
    public string ToData(List<Dictionary<WinLoseType, string>> dictionary)
    {
        return JsonConvert.SerializeObject(dictionary);
    }

    public List<Dictionary<WinLoseType, string>> FromData() 
    {
        if (string.IsNullOrEmpty(Data))
            return new List<Dictionary<WinLoseType, string>>();
			
        return JsonConvert.DeserializeObject<List<Dictionary<WinLoseType, string>>>(Data);
    }
}