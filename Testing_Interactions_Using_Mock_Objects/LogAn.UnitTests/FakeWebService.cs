namespace LogAn.UnitTests;

public class FakeWebService : IWebService
{
    public string LastError { get; set; }

    public void LogError(string message)
    {
        LastError = message;
    }
}
