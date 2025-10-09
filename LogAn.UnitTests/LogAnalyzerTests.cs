namespace LogAn.UnitTests;

public class LogAnalyzerTests
{
    [Fact]
    public void IsValidLogFileName_BadExtension_ReturnFalse()
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        bool result = analyzer.IsValidLogFileName("lewithbadextension.foo");
        Assert.Equal(result, false);
    }
}
