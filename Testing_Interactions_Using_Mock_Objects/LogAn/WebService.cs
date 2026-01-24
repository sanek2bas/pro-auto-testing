namespace LogAn;

public interface IWebService
{
    void LogError(string message);
}

public class FakeWebService : IWebService
{
    public string LastError { get; set; }

    public void LogError(string message)
    {
        throw new NotImplementedException();
    }
}