namespace LogAn;

public class LogAnalyzer3
{
    private ILogger logger;
    private IWebService3 webService;

    public int MinNameLength { get; set; }

    public int SeverityError { get; set; }

    public LogAnalyzer3(ILogger logger, IWebService3 webService)
    {
        this.logger = logger;
        this.webService = webService;
    }

    public void Analyze(string filename)
    {
        if (filename.Length < MinNameLength)
        {
            try
            {
                logger.LogError($"The name is too short {filename}");
            }
            catch (Exception e)
            {
                webService.Write(new ErrorInfo(SeverityError, e.Message));
            }
        }
    }
}
