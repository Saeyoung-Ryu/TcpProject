using System;
using System.Globalization;
using Enum;
using MessagePack;
using Protocol2;

namespace ClientConsoleApp
{
    public class Program
    {
        public static string Nickname;
        
        static async Task Main(string[] args)
        {
            await PrintLoginAsync();

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
            Console.WriteLine("Enter Login Method : ");
            string loginMethod = Console.ReadLine();

            if (loginMethod == "1")
            {
                Console.Write("Enter Nickname to Login : ");
                Console.WriteLine("=====================================");
                Nickname = Console.ReadLine();
            
                var loadDataReq = new LoadDataReq
                {
                    ProtocolId = ProtocolId.LoadData,
                    NickName = Nickname
                };

                try
                {
                    var res = await HttpManager.SendHttpServerRequestAsync(loadDataReq);
                    var loadDataRes = (LoadDataRes) res;
                    
                    if (loadDataRes.Result != Result.None)
                        throw new Exception();
                    
                    Console.WriteLine($"Welcome to the game {Nickname}! [Created at UTC : {loadDataRes.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")}]");
                }
                catch (Exception e)
                {
                    Console.WriteLine(Result.LoadDataFailed);
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
                
                    Console.WriteLine($"Welcome to the game {Nickname}! [Created at UTC : {loginRes.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")}]");
                }
                catch (Exception e)
                {
                    Console.WriteLine(Result.LoginFailed);
                    await PrintLoginAsync();
                }
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

/*using System;
using System.Net.Http;
using System.Threading.Tasks;
using MessagePack;
using Protocol2;

namespace ClientConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var loadDataReq = new LoadDataReq
            {
                ProtocolId = ProtocolId.LoadData,
                NickName = "Test12"
            };

            var editNicknameReq = new EditNicknameReq()
            {
                ProtocolId = ProtocolId.EditNickname,
                ChangedNickname = "Amy123",
                OriginalNickname = "NoNo"
            };
            
            var getMatchHistoryReq = new GetMatchHistoryReq
            {
                ProtocolId = ProtocolId.GetMatchHistory,
                NickName = "Sy123444"
            };

            var setRank = new SetRankReq()
            {
                ProtocolId = ProtocolId.SetRank,
                LoserNickname = "Amy123",
                WinnerNickname = "Test12"
            };

            var getRank = new GetRankReq()
            {
                ProtocolId = ProtocolId.GetRank,
                NickName = "Sy1234"
            };
            
            var res = await HttpManager.SendHttpServerRequestAsync(getRank);
            
            var a = (GetRankRes) res;
            
            Console.WriteLine(a.WinCount);
            Console.WriteLine(a.LoseCount);
            Console.WriteLine(a.Point);
            Console.WriteLine(a.Ranking);
        }

        static async Task<ProtocolRes> SendHttpServerRequestAsync<T>(T protocol)
        {
            Console.WriteLine("Here");
            // Create an instance of LoadDataReq with sample data

            ProtocolReq requestData = new ProtocolReq
            {
                Protocol = (Protocol2.Protocol)(object)protocol
            };

            // Serialize the request data to MessagePack format
            byte[] requestBytes = MessagePackSerializer.Serialize(requestData);

            // Specify the server URL
            string serverUrl = "http://localhost:8080"; // Adjust the URL based on your server configuration
            Console.WriteLine("Here1");

            // Send the HTTP request to the server
            using (var httpClient = new HttpClient())
            using (var content = new ByteArrayContent(requestBytes))
            {
                Console.WriteLine("Here33");
                content.Headers.Add("Content-Type", "application/octet-stream");

                Console.WriteLine(serverUrl);
                Console.WriteLine(content.ToString());
                var response = await httpClient.PostAsync($"{serverUrl}/", content);
                Console.WriteLine("Here44");

                // Check if the request was successful (status code 200)
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Here2");
                    // Read the response content
                    byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();

                    Console.WriteLine("Here3");
                    // Deserialize the response data from MessagePack format
                    var responseDataRes = MessagePackSerializer.Deserialize<ProtocolRes>(responseBytes);
                    var responseData = responseDataRes;

                    return responseData;
                    // Process the response data
                    var a = (LoadDataRes) responseData;
                    return a;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }
        }
    }
}*/