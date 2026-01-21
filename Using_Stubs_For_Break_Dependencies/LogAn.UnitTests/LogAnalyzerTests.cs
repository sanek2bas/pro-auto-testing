namespace LogAn.UnitTests;

public class LogAnalyzerTests
{
    [Fact]
    public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
    {
        FakeExtensionManager myFakeManager = new FakeExtensionManager();
        myFakeManager.WillBeValid = true;
        LogAnalyzer log = new LogAnalyzer(myFakeManager);

        bool result = log.IsValidLogFileName("short.ext");

        Assert.True(result);
    }
}
