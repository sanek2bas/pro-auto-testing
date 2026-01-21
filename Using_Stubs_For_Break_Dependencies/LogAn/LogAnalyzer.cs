namespace LogAn;

public class LogAnalyzer
{
    private IExtensionManager manager;

    public LogAnalyzer(IExtensionManager mgr)
    {
        manager = mgr;
    }

    public bool IsValidLogFileName(string fileName)
    {
        try
        {
            return manager.IsValid(fileName);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
