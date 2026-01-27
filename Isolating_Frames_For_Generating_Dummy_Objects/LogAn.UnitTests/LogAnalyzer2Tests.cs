using NSubstitute;
using System;
using System.Runtime.InteropServices.JavaScript;

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

    [Fact]
    public void Analyze_LoggerThrows_CallsWebService_With_NStub()
    {
        var mockWebService = Substitute.For<IWebService>();
        var stubLogger = Substitute.For<ILogger>();
        stubLogger.When(
            logger => logger.LogError(Arg.Any<string>()))
            .Do(info => { throw new Exception("fake exception"); });

        var analyzer = new LogAnalyzer2(stubLogger, mockWebService);

        analyzer.MinNameLength = 10;
        analyzer.Analyze("Short.txt");

        mockWebService.Received()
            .Write(Arg.Is<string>(s => s.Contains("fake exception")));
    }
}
