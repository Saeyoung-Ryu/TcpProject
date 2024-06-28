using HttpServer.Cache;
using Enum;
using HttpServer;

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

    public static async Task<Player?> GetPlayerWithEmailAsync(string email, bool insert = false, bool needToCache = false, string password = "")
    {
        var player = await AccountDB.GetPlayerWithEmailAsync(email, needToCache);

        // password check
        if (password != "")
        {
            if (player == null)
                return null;
            
            var checkPassword = MyUtil.EncryptManager.VerifyPassword(password, player.Password, player.PasswordSalt);

            if (checkPassword == false)
                throw new MyException(Result.WrongPassword);
        }
        
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