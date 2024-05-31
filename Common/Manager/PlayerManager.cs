using Common.Redis;
using Enum;

namespace Common;

public class PlayerManager
{
    public static async Task<Player?> GetPlayerWithNicknameAsync(string nickname, bool insert = false, bool needToCache = false)
    {
        var player = await AccountDB.GetPlayerWithNicknameAsync(nickname, needToCache);

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
            
            if (needToCache)
                await RedisService.SetKeyValueAsync(player.Suid.ToString(), player);
        }

        return player;
    }

    public static async Task<Player?> GetPlayerWithEmailAsync(string email, bool insert = false, bool needToCache = false)
    {
        var player = await AccountDB.GetPlayerWithEmailAsync(email, needToCache);

        if (player == null && insert)
        {
            player = new Player()
            {
                Email = email,
                Suid = LoginManager.GenerateUniqueSuid(),
                AccountId = "",
                LoginType = LoginType.Guest,
                CreateTime = DateTime.UtcNow
            };
            
            await AccountDB.SetPlayerAsync(player);
            
            if (needToCache)
                await RedisService.SetKeyValueAsync(player.Suid.ToString(), player);
        }

        return player;
    }
}