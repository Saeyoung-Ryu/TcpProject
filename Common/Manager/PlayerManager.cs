using Enum;

namespace Common;

public class PlayerManager
{
    public static async Task<Player?> GetPlayerWithNicknameAsync(string nickname, bool insert = false)
    {
        var player = await AccountDB.GetPlayerWithNicknameAsync(nickname);

        if (player == null && insert)
        {
            player = new Player()
            {
                Nickname = nickname,
                Suid = LoginManager.GenerateUniqueSuid(),
                AccountId = "",
                LoginType = LoginType.Guest,
                CreateTime = DateTime.UtcNow
            };
            
            await AccountDB.SetPlayerAsync(player);
        }

        return player;
    }

}