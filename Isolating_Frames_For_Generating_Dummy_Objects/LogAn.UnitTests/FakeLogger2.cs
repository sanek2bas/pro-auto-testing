namespace LogAn.UnitTests;

public class FakeLogger2 : ILogger
{
    public Exception WillThrow { get; set; }

    public string LoggerGotMessage { get; set; }

    public void LogError(string message)
    {
        LoggerGotMessage = message;
        if (WillThrow != null)
        {
            throw WillThrow;
        }
    }
}