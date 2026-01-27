namespace LogAn.UnitTests;

public class LogAnalyzer2Tests
{
    [Fact]
    public void Analyze_LoggerThrows_CallsWebService()
    {
        FakeWebService mockWebService = new FakeWebService();

        FakeLogger2 stubLogger = new FakeLogger2();
        stubLogger.WillThrow = new Exception("fake exception");
        var analyzer2 = new LogAnalyzer2(stubLogger, mockWebService);

        analyzer2.MinNameLength = 8;
        string tooShortFileName ="abc.ext";
        analyzer2.Analyze(tooShortFileName);

        Assert.Contains("fake exception", mockWebService.MessageToWebService);
    }
}
