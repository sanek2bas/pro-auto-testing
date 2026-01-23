namespace LogAn.UnitTests;

public class LogAnalyzerUsingFactoryMethod2Tests
{
    [Fact]
    public void OverrideTestWithoutStub()
    {
        TestableLogAnalyzer2 logan = new TestableLogAnalyzer2();
        logan.IsSupported = true;

        bool result = logan.IsValidLogFileName("file.ext");
        Assert.True(result, "file.txt");
    }
}
