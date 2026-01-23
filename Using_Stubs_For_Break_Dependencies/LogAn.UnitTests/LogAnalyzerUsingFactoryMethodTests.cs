namespace LogAn.UnitTests;

public class LogAnalyzerUsingFactoryMethodTests
{
    [Fact]
    public void OverrideTest()
    {
        FakeExtensionManager stub = new FakeExtensionManager();
        stub.WillBeValid = true;
        TestableLogAnalyzer logan = new TestableLogAnalyzer(stub);

        bool result = logan.IsValidLogFileName("file.ext");
        
        Assert.True(result);
    }
}
