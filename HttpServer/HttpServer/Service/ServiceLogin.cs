using Common;
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
public class ServiceLogin : IService
{
    public ProtocolId ProtocolId { get; set; } = ProtocolId.Login;

    public async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request)
    {
        var req = (LoginReq)request;
        var res = new LoginRes();
        
        try
        {
            if (req.LoginType == LoginType.Guest)
            {
                var player = await PlayerManager.GetPlayerWithEmailAsync(req.Email);

                if (player == null)
                    throw new MyException(Result.NotExistEmail);

                var verifyResult = EncryptManager.VerifyPassword(req.Password, player.Password, player.PasswordSalt);

                if (verifyResult == false)
                    throw new MyException(Result.WrongPassword);
                
                res.CreateTime = player.CreateTime;
                res.NickName = player.Nickname;
            }
            if (req.LoginType == LoginType.Google)
            {
                UserCredential credential = await LoginManager.GetUserCredentialForGoogleAsync();

                // OAuth2 API 클라이언트를 생성합니다.
                var oauth2Service = new Oauth2Service(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential
                });

                // 사용자의 정보를 가져옵니다.
                Userinfo userInfo = await oauth2Service.Userinfo.Get().ExecuteAsync();
                
                var accountId = userInfo.Id;

                var player = await AccountDB.GetPlayerWithAccountIdAsync(accountId, req.LoginType);

                if (player == null)
                    throw new MyException(Result.NotExistEmail);
                
                res.CreateTime = player.CreateTime;
                res.NickName = player.Nickname;
            }
        }
        catch (MyException e)
        {
            res.Result = e.Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            res.Result = Result.LoginFailed;
        }
        
        return res;
    }
}