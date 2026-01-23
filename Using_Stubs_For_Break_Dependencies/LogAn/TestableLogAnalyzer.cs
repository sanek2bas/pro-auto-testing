namespace LogAn;

public class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod
{
    private IExtensionManager manager;

    public TestableLogAnalyzer(IExtensionManager mgr)
    {
        manager = mgr;
    }
    
    protected override IExtensionManager GetManager()
    {
        return manager;
    }
}
