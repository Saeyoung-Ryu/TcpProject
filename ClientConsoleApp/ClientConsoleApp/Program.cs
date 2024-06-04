using System;
using System.Globalization;
using Common;
using Enum;
using MessagePack;
using Protocol2;

namespace ClientConsoleApp
{
    public class Program
    {
        public static Player Player { get; set; }
        public static string Nickname;
        
        static async Task Main(string[] args)
        {
            await PrintLoginAsync();
            
            var loadDataReq = new LoadDataReq()
            {
                ProtocolId = ProtocolId.LoadData,
                Player = Player
            };
            
            var res = await HttpManager.SendHttpServerRequestAsync(loadDataReq);
            var loadDataRes = (LoadDataRes) res;
                    
            if (loadDataRes.Result != Result.None)
                throw new MyException(loadDataRes.Result);

            Console.WriteLine("=====================================");
            Console.WriteLine($"Attendance Day : {loadDataRes.PlayerAttendance.Day}");

            while (true)
            {
                var selectedMenuNum = PrintMenu();
            
                switch (selectedMenuNum)
                {
                    case "1":
                        EnterGame();
                        break;
                    case "2":
                        await PrintRankAsync();
                        break;
                    case "3":
                        await PrintMatchHistoryAsync();
                        break;
                    case "4":
                        await PrintEditNicknameAsync();
                        break;
                }
            }
            
        }
        static void EnterGame()
        {
            Client client = new Client("127.0.0.1", 3360);
        }

        static async Task PrintEditNicknameAsync()
        {
            Console.WriteLine("=====================================");
            Console.Write("Enter New Nickname : ");
            var newNickname = Console.ReadLine();
            
            var editNicknameReq = new EditNicknameReq
            {
                ProtocolId = ProtocolId.EditNickname,
                ChangedNickname = newNickname,
                OriginalNickname = Nickname
            };
            var res = await HttpManager.SendHttpServerRequestAsync(editNicknameReq);
            var editNicknameRes = (EditNicknameRes) res;
            
            if (editNicknameRes.Success)
            {
                Nickname = newNickname;
                Console.WriteLine("Nickname Changed Successfully");
            }
            else
            {
                Console.WriteLine("Nickname Already Exists");
            }
            
            Console.WriteLine("=====================================");
        }

        static async Task PrintMatchHistoryAsync()
        {
            var getMatchHistoryReq = new GetMatchHistoryReq
            {
                ProtocolId = ProtocolId.GetMatchHistory,
                NickName = Nickname
            };
            
            var res = await HttpManager.SendHttpServerRequestAsync(getMatchHistoryReq);
            var getMatchHistoryRes = (GetMatchHistoryRes) res;
            
            Console.WriteLine("=====================================");
            if (getMatchHistoryRes.MatchHistoryListDic == null || getMatchHistoryRes.MatchHistoryListDic.Count == 0)
            {
                Console.WriteLine("No Match History");
            }
            else
            {
                foreach (var matchHistory in getMatchHistoryRes.MatchHistoryListDic)
                {
                    Console.WriteLine($"Win : {matchHistory[WinLoseType.Win]} / Lose : {matchHistory[WinLoseType.Lose]}");
                }
            }
            Console.WriteLine("=====================================");
        }

        static async Task PrintRankAsync()
        {
            var getRankReq = new GetRankReq
            {
                ProtocolId = ProtocolId.GetRank,
                NickName = Nickname
            };
            
            var res = await HttpManager.SendHttpServerRequestAsync(getRankReq);
            var getRankRes = (GetRankRes) res;

            string ranking = getRankRes.Ranking == 0 ? "No Rank" : getRankRes.Ranking.ToString();
            
            Console.WriteLine("=====================================");
            Console.WriteLine($"Win : {getRankRes.WinCount} / Lose : {getRankRes.LoseCount} / Point : {getRankRes.Point}");
            Console.WriteLine($"Ranking : {ranking}");
            Console.WriteLine("=====================================");
        }

        static async Task PrintLoginAsync()
        {
            Console.WriteLine("1. Login as Guest");
            Console.WriteLine("2. Login with Google Account");
            Console.WriteLine("3. Sign Up as Guest");
            Console.WriteLine("4. Sign Up with Google Account");
            Console.WriteLine("Enter Login Method : ");
            string loginMethod = Console.ReadLine();

            if (loginMethod == "1")
            {
                Console.Write("Enter Email to Login : ");
                string email = Console.ReadLine();
                Console.Write("Enter password : ");
                string password = Console.ReadLine();
                Console.WriteLine("=====================================");
            
                var loginReq = new LoginReq
                {
                    ProtocolId = ProtocolId.Login,
                    Email = email,
                    Password = password,
                    LoginType = LoginType.Guest
                };

                try
                {
                    var res = await HttpManager.SendHttpServerRequestAsync(loginReq);
                    var logInRes = (LoginRes) res;
                    
                    if (logInRes.Result != Result.None)
                        throw new MyException(logInRes.Result);

                    Player = logInRes.Player;
                    
                    Console.WriteLine($"Welcome to the game {Nickname}! [Created at UTC : {logInRes.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")}]");
                }
                catch (MyException e)
                {
                    Console.WriteLine(e.Result);
                    await PrintLoginAsync();
                }
            }
            else if (loginMethod == "2")
            {
                var loginReq = new LoginReq
                {
                    ProtocolId = ProtocolId.Login,
                    LoginType = LoginType.Google
                };

                try
                {
                    var res = await HttpManager.SendHttpServerRequestAsync(loginReq);
                    var loginRes = (LoginRes) res;

                    if (loginRes.Result != Result.None)
                        throw new Exception();
                    
                    Player = loginRes.Player;
                
                    Console.WriteLine($"Welcome to the game {Nickname}! [Created at UTC : {loginRes.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")}]");
                }
                catch (Exception e)
                {
                    Console.WriteLine(Result.LoginFailed);
                    await PrintLoginAsync();
                }
            }
            else if (loginMethod == "3")
            {
                Console.Write("Enter Email to Sign Up : ");
                string email = Console.ReadLine();
                
                var signInEmailAuthSendStepReq = new SignInEmailAuthSendStepReq()
                {
                    ProtocolId = ProtocolId.SignInEmailAuthSendStep,
                    Email = email,
                    LoginType = LoginType.Guest
                };
                
                var res = await HttpManager.SendHttpServerRequestAsync(signInEmailAuthSendStepReq);
                var signInEmailAuthSendStepRes = (SignInEmailAuthSendStepRes) res;
                
                if (signInEmailAuthSendStepRes.Result != Result.None)
                {
                    Console.WriteLine(signInEmailAuthSendStepRes.Result);
                    await PrintLoginAsync();
                }
                else
                {
                    Console.WriteLine("Verification Email Sent!");
                    Console.WriteLine("Enter Verification Code : ");
                    string verificationCode = Console.ReadLine();
                    
                    var signInEmailAuthVerifyStepReq = new SignInEmailAuthVerifyStepReq()
                    {
                        ProtocolId = ProtocolId.SignInEmailAuthVerifyStep,
                        Email = email,
                        Code = verificationCode
                    };
                
                    var response = await HttpManager.SendHttpServerRequestAsync(signInEmailAuthVerifyStepReq);
                    var signInEmailAuthVerifyStepRes = (SignInEmailAuthVerifyStepRes) response;

                    if (signInEmailAuthVerifyStepRes.VerifyResult = true)
                    {
                        Console.WriteLine("Enter Password : ");
                        string password = Console.ReadLine();
                        Console.WriteLine("Enter Nickname : ");
                        string nickName = Console.ReadLine();
                        
                        var signInEmailAuthFinalStepReq = new SignInEmailAuthFinalStepReq()
                        {
                            ProtocolId = ProtocolId.SignInEmailAuthFinalStep,
                            Password = password,
                            NickName = nickName,
                            Email = email
                        };
                        
                        var finalResponse = await HttpManager.SendHttpServerRequestAsync(signInEmailAuthFinalStepReq);
                        var signInEmailAuthFinalStepRes = (SignInEmailAuthFinalStepRes) finalResponse;
                        
                        if (signInEmailAuthSendStepRes.Result != Result.None)
                        {
                            Console.WriteLine(signInEmailAuthSendStepRes.Result);
                            await PrintLoginAsync();
                        }
                        else
                            Player = signInEmailAuthFinalStepRes.Player;
                    }
                }
            }
            else if (loginMethod == "4")
            {
                
            }
            else
            {
                Console.WriteLine("Invalid Input");
                return;
            }
        }
        
        static string PrintMenu()
        {
            Console.WriteLine("1. Play Game   2. Check Rank   3. Check Match History   4. Edit Nickname");
            Console.Write("Select Num : ");
            return Console.ReadLine();
        }
    }
}