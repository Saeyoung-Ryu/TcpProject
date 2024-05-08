using Common;
using MyUtil;

namespace HttpServer.Shared.Common;

public class SMTPInfo
{
#pragma warning disable 8601    
#pragma warning disable 8618    
    
    public static string FromAddress = "usaeyoung9514@gmail.com";
    public static string FromPassword = ""; // 2차인증 비밀번호
    public static string SmtpServer = "smtp.gmail.com"; // 이메일 제공자의 SMTP 서버 주소
    public static int Port = 587; // 포트 번호 (보통 587 또는 465)
    public static bool EnableSSL = true; // SSL 사용 여부
}