

namespace TcpProjectServer;

public class GameManager
{
    public static (int Num1, int Num2) GetTwoRandomNumbers()
    {
        Random random = new Random();
        return (random.Next(10, 30), random.Next(10, 30));
    }
}