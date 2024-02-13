namespace Common;

public class PlayerManager
{
    public static async Task<(string Nickname, DateTime CreateTime)> GetPlayerAsync(string nickname)
    {
        var player = await AccountDB.GetPlayerAsync(nickname);

        if (player == null)
        {
            await AccountDB.SetPlayerAsync(nickname);
            return (nickname, DateTime.UtcNow);
        }
        
        return (player.Nickname, player.CreateTime);
    }
}