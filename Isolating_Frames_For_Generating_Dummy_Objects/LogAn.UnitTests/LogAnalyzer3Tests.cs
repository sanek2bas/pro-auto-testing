using NSubstitute;

namespace LogAn.UnitTests;

public class LogAnalyzer3Tests
{
    [Fact]
    public void Analyze_LoggerThrows_CallsWebServiceWithNSubObject()
    {
        var mockWebService = Substitute.For<IWebService3>();
        var stubLogger = Substitute.For<ILogger>();
        stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
            .Do(info => { throw new Exception("fake exception"); });

        var analyzer = new LogAnalyzer3(stubLogger, mockWebService);
        analyzer.MinNameLength = 10;
        analyzer.SeverityError = 1000;
        analyzer.Analyze("Short.txt");

        mockWebService.Received()
            .Write(Arg.Is<ErrorInfo>(info => info.Severity == 1000
                                          && info.Message.Contains("fake exception")));
    }

    [Fact]
    public void Analyze_LoggerThrows_CallsWebServiceWithNSubObjectCompare()
    {
        var mockWebService = Substitute.For<IWebService3>();
        var stubLogger = Substitute.For<ILogger>();
        stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
            .Do(info => { throw new Exception("fake exception"); });

        var analyzer = new LogAnalyzer3(stubLogger, mockWebService);
        analyzer.MinNameLength = 10;
        analyzer.SeverityError = 1000;
        analyzer.Analyze("Short.txt");

        var expected = new ErrorInfo(1000, "fake exception");
        mockWebService.Received().Write(expected);
    }
}
