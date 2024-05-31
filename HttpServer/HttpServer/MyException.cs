using Enum;

namespace HttpServer;

public class MyException : Exception
{
    public Result Result { get; protected set; }

    public MyException(Result result) : base($"Result = {result}")
    {
        Result = result;
    }

    public MyException(Result result, string message) : base($"Result = {result}, " + message)
    {
        Result = result;
    }

    public MyException(Result result, string format, params object[] args) : base($"Result = {result}, " + string.Format(format, args))
    {
        Result = result;
    }
}