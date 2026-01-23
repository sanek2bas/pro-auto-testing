namespace LogAn;

public class LogAnalyzerUsingFactory
{
    private IExtensionManager manager;

    public LogAnalyzerUsingFactory()
    {
        manager = ExtensionManagerFactory.Instance.Create();
    }

    public bool IsValidLogFileName(string fileName)
    {
        return manager.IsValid(fileName)
            && Path.GetFileNameWithoutExtension(fileName).Length >= 5;
    }
}