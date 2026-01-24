namespace LogAn.UnitTests;

public class LogAnalyzer2Tests
{
    [Fact]
    public void Analyze_WebServiceThrows_SendsEmail()
    {
        FakeWebService2 stubService = new FakeWebService2();
        stubService.ToThrow = new Exception("fake exception");

        FakeEmailService2 mockEmail = new FakeEmailService2();
        
        LogAnalyzer2 log = new LogAnalyzer2(stubService, mockEmail);
        string tooShortFileName ="abc.ext";
        log.Analyze(tooShortFileName);

        Assert.Contains("someone@somewhere.com", mockEmail.To);
        Assert.Contains("fake exception", mockEmail.Body);
        Assert.Contains("can't log", mockEmail.Subject);
    }
}
