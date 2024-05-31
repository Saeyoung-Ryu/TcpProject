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
public class ServiceSignInEmailAuthSendStep : IService
{
    public ProtocolId ProtocolId { get; set; } = ProtocolId.SignInEmailAuthSendStep;

    public async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request)
    {
        var req = (SignInEmailAuthSendStepReq)request;
        var res = new SignInEmailAuthSendStepRes();
        
        try
        {
            var player = await PlayerManager.GetPlayerWithEmailAsync(req.Email);

            if (player != null)
                throw new MyException(Result.EmailAlreadyExists);
            
            if (req.LoginType == LoginType.Google)
            {
                UserCredential credential = await LoginManager.GetUserCredentialForGoogleAsync();
                
                var oauth2Service = new Oauth2Service(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential
                });
                
                Userinfo userInfo = await oauth2Service.Userinfo.Get().ExecuteAsync();
                var accountId = userInfo.Id;

                player = new Player()
                {
                    Suid = LoginManager.GenerateUniqueSuid(),
                    AccountId = accountId,
                    LoginType = req.LoginType,
                    Nickname = "",
                    CreateTime = DateTime.UtcNow
                };
                
                await AccountDB.SetPlayerAsync(player);
                res.AuthResult = true;
            }
            if (req.LoginType == LoginType.Guest)
            {
                var token = await LoginManager.SendAuthTokenMailAsync(req.Email);

                if (token == "")
                    throw new MyException(Result.FailedToSendVerificationCode);
                
                // 5분동안 저장되는 토큰 생성
                await RedisService.SetKeyValueAsync(req.Email, token, TimeSpan.FromMinutes(5));
                
                res.AuthResult = true;
            }
        }
        catch (MyException e)
        {
            res.Result = e.Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return res;
    }
}