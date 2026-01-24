namespace LogAn;

public class LogAnalyzer
{
    private IWebService service;

    public LogAnalyzer(IWebService service)
    {
        this.service = service;
    }

    public void Analyze(string fileName)
    {
        if (fileName.Length < 8)
            service.LogError("The name is too short");
    }
}
