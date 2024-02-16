using Newtonsoft.Json;

namespace Common;

public class MatchHistory
{
    public long PlayerSeq { get; set; }
    public string Data { get; set; } // json Key : GameNum, Value : ( Key : WinLoseType, Value : Nickname)
    // {"1":{"1":"amy","2":"samy"},"2":{"1":"amy2","2":"samy"},"3":{"1":"amy4","2":"samy"}}
    public string ToData(Dictionary<int, Dictionary<WinLoseType, string>> dictionary)
    {
        return JsonConvert.SerializeObject(dictionary);
    }

    public Dictionary<int, Dictionary<WinLoseType, string>> FromData() 
    {
        if (string.IsNullOrEmpty(Data))
            return new Dictionary<int, Dictionary<WinLoseType, string>>();
			
        return JsonConvert.DeserializeObject<Dictionary<int, Dictionary<WinLoseType, string>>>(Data);
    }
}