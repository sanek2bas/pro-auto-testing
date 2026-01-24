namespace LogAn.UnitTests;

internal class FakeWebService2 : IWebService
{
    public Exception ToThrow { get; set; }

    public void LogError(string message)
    {
        if (ToThrow == null)
            return;
        throw ToThrow;
    }
}
