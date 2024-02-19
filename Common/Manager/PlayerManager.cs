namespace Common;

public class PlayerManager
{
    public static async Task<Player?> GetPlayerWithNicknameAsync(string nickname, bool insert = false)
    {
        var player = await AccountDB.GetPlayerWithNicknameAsync(nickname);

        if (player == null && insert)
        {
            await AccountDB.InsertPlayerAsync(nickname);
            player = new Player()
            {
                Nickname = nickname,
                CreateTime = DateTime.UtcNow
            };
        }

        return player;
    }

}