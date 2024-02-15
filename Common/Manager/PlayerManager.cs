namespace Common;

public class PlayerManager
{
    public static async Task<(string Nickname, DateTime CreateTime)> GetPlayerWithNicknameAsync(string nickname)
    {
        var player = await AccountDB.GetPlayerWithNicknameAsync(nickname);

        if (player == null)
        {
            await AccountDB.InsertPlayerAsync(nickname);
            return (nickname, DateTime.UtcNow);
        }
        
        return (player.Nickname, player.CreateTime);
    }
}