using Common;

namespace TcpProjectServer;

public class GameManager
{
    public static (int Num1, int Num2) GetTwoRandomNumbers()
    {
        Random random = new Random();
        int minSumValue = int.Parse(ServerVariable.MinSumValue);
        int maxSumValue = int.Parse(ServerVariable.MaxSumValue);
        return (random.Next(minSumValue, maxSumValue), random.Next(minSumValue, maxSumValue));
    }
}