namespace LogAn.UnitTests;

public class FakeWebService : IWebService
{
    public string MessageToWebService { get; private set; }

    public void Write(string message)
    {
        MessageToWebService = message;
    }
}
