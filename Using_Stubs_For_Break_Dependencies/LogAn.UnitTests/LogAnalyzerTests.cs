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

    [Fact]
    public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
    {
        FakeExtensionManager myFakeManager = new FakeExtensionManager();
        string exMessage = "It's fake copy";
        myFakeManager.WillThrow = new Exception(exMessage);
        LogAnalyzer log = new LogAnalyzer(myFakeManager);

        var ex = Assert.Throws<Exception>(
            () => log.IsValidLogFileName("anything.anyextension"));

        Assert.Equal(exMessage, ex.Message);
    }
}
