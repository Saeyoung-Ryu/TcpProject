using Common;
using Common.Redis;
using Enum;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;
using HttpServer;
using Microsoft.AspNetCore.Identity;
using MyUtil;
using Protocol2;

namespace Service;

[ProtocolHandler]
public class ServiceSignInEmailAuthFinalStep : IService
{
    public ProtocolId ProtocolId { get; set; } = ProtocolId.SignInEmailAuthFinalStep;

    public async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request)
    {
        var req = (SignInEmailAuthFinalStepReq)request;
        var res = new SignInEmailAuthFinalStepRes();
        
        try
        {
            var player = await PlayerManager.GetPlayerWithEmailAsync(req.Email); // 회원가입사이 같은 이메일로 로그인했을시 방지
            
            if (player != null)
                throw new  MyException(Result.EmailAlreadyExists);
            
            var salt = EncryptManager.GenerateSalt(10);
            var passwordHash = EncryptManager.HashPassword(req.Password, salt);

            player = new Player()
            {
                Suid = LoginManager.GenerateUniqueSuid(),
                AccountId = "",
                CreateTime = DateTime.UtcNow,
                Email = req.Email,
                LoginType = LoginType.Guest,
                Nickname = req.NickName,
                Password = passwordHash,
                PasswordSalt = salt
            };

            await AccountDB.SetPlayerAsync(player);
            res.FinalResult = true;
        }
        catch (MyException e)
        {
            res.FinalResult = false;
            res.Result = e.Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return res;
    }
}