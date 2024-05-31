using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Enum;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using HttpServer;
using HttpServer.Shared.Common;
using MySqlConnector;
using MyUtil;

namespace Common
{
    public class LoginManager
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly Random random = new Random();
        
        private static readonly object seqLock = new object();
        private static long lastTimestamp = -1;
        private static long seq = 0;

        public static async Task RefreshSeqAsync()
        {
            await using (var conn = new MySqlConnection(ServerInfoConfig.Instance.ConnectionString))
            {
                var lastRowSeq = await conn.QuerySingleOrDefaultAsync<long>("SELECT seq FROM tblPlayer ORDER BY `seq` DESC LIMIT 1;");
                
                if (lastRowSeq != null)
                    seq = lastRowSeq + 1;
            }
            
            MyLogger.WriteLineInfo($"seq: {seq} has been refreshed.");
        }

        public static long GenerateUniqueSuid()
        {
            lock (seqLock)
            {
                long timestamp = GetTimestamp();

                if (timestamp < lastTimestamp)
                {
                    throw new Exception("Timestamps are not ordered correctly.");
                }

                if (timestamp == lastTimestamp)
                {
                    seq = (seq + 1) & 0xFFF;
                    if (seq == 0)
                    {
                        // If we've exhausted the sequence numbers for this timestamp, wait until the next millisecond
                        timestamp = WaitNextMillis(lastTimestamp);
                    }
                }

                lastTimestamp = timestamp;

                // Generate unique ID by combining timestamp and sequence number
                long uniqueId = (timestamp << 22) | seq;
                seq++;

                return uniqueId;
            }
        }

        private static long GetTimestamp()
        {
            // Unix timestamp in milliseconds
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        private static long WaitNextMillis(long lastTimestamp)
        {
            long timestamp = GetTimestamp();
            while (timestamp <= lastTimestamp)
            {
                timestamp = GetTimestamp();
            }
            return timestamp;
        }

        public static async Task<UserCredential> GetUserCredentialForGoogleAsync()
        {
            UserCredential credential;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { "https://www.googleapis.com/auth/userinfo.email" },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)
                );
            }

            return credential;
        }

        public static async Task<string> SendAuthTokenMailAsync(string email)
        {
            StringBuilder bodyStringBuilder = new StringBuilder();

            string token = GenerateToken(10);
            bodyStringBuilder.AppendLine($"안녕하세요! 이메일 인증 메일입니다. 인증코드는 다음과 같습니다 : {token}");
    
            SmtpClient client = new SmtpClient(SMTPInfo.SmtpServer)
            {
                Port = SMTPInfo.Port,
                Credentials = new NetworkCredential(SMTPInfo.FromAddress, SMTPInfo.FromPassword),
                EnableSsl = SMTPInfo.EnableSsL
            };

            MailMessage mailMessage = new MailMessage(SMTPInfo.FromAddress, email)
            {
                Subject = "인증 메일",
                Body = bodyStringBuilder.ToString()
            };
    
            try
            {
                client.Send(mailMessage);
                Console.WriteLine("이메일이 성공적으로 전송되었습니다.");
            }
            catch (MyException ex)
            {
                throw new MyException(Result.FailedToSendVerificationCode);
            }

            return token;
        }
        
        private static string GenerateToken(int length)
        {
            var tokenBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                char randomChar = Alphabet[random.Next(Alphabet.Length)];
                tokenBuilder.Append(randomChar);
            }
            return tokenBuilder.ToString();
        }
    }
}
