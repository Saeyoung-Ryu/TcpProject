using Common;
using HttpServer;
using Protocol2;

namespace Service;

[ProtocolHandler]
public class ServiceEditNickname : IService
{
    public ProtocolId ProtocolId { get; set; } = ProtocolId.EditNickname;

    public async Task<ProtocolRes> ProcessAsync(HttpContext context, Protocol request)
    {
        var req = (EditNicknameReq)request;
        var res = new EditNicknameRes();

        try
        {
            var originalNicknamePlayer = await PlayerManager.GetPlayerWithNicknameAsync(req.OriginalNickname);
            var changedNicknamePlayer = await PlayerManager.GetPlayerWithNicknameAsync(req.ChangedNickname);

            if (changedNicknamePlayer == null && originalNicknamePlayer != null) // 중복닉네임이 없을떄
            {
                originalNicknamePlayer.Nickname = req.ChangedNickname;

                await AccountDB.SetPlayerAsync(originalNicknamePlayer);
                res.Success = true;
            }
            else
                res.Success = false;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return res;
    }
}