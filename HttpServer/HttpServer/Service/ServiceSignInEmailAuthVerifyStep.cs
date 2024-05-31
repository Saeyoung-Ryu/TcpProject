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
public class ServiceSignInEmailAuthVerifyStep : IService
{
    public ProtocolId ProtocolId { get; set; } = ProtocolId.SignInEmailAuthVerifyStep;

    public async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request)
    {
        var req = (SignInEmailAuthVerifyStepReq)request;
        var res = new SignInEmailAuthVerifyStepRes();
        
        try
        {
            var token = await RedisService.GetValueAsync<string>(req.Email);

            if (token == null)
                throw new MyException(Result.VerificationCodeExpired);
            
            if (token != req.Code)
                throw new MyException(Result.WrongVerificationCode);

            res.VerifyResult = true;
        }
        catch (MyException e)
        {
            res.VerifyResult = false;
            res.Result = e.Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return res;
    }
}