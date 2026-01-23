namespace LogAn;

public class LogAnalyzerUsingFactoryMethod2
{
    public bool IsValidLogFileName(string fileName)
    {
        return IsValid(fileName);
    }

    protected virtual bool IsValid(string fileName)
    {
        FileExtensionManager mgr = new FileExtensionManager();
        return mgr.IsValid(fileName);
    }
}
