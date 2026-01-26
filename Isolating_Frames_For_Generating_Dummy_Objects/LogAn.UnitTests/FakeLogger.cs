namespace LogAn.UnitTests;

public class FakeLogger : ILogger
{
    public string LastError { get; private set; }

    public void LogError(string message)
    {
        LastError = message;
    }
}
