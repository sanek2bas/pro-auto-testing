namespace LogAn.UnitTests;

public class LogAnalyzerTests
{
    [Fact]
    public void Analyze_TooShortFileName_CallLogger()
    {
        FakeLogger logger = new FakeLogger();
        LogAnalyzer analyzer = new LogAnalyzer(logger);

        analyzer.MinNameLength = 6;
        analyzer.Analyze("a.txt");
        
        Assert.Contains("is too short", logger.LastError);
    }
}