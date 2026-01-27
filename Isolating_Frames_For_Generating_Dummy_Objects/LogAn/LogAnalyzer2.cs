using System.Xml.Linq;

namespace LogAn;

public class LogAnalyzer2
{
    private ILogger logger;
    private IWebService webService;

    public int MinNameLength { get; set; }

    public LogAnalyzer2(ILogger logger, IWebService webService)
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
                webService.Write($"Registar error: {e}");
            }
        }
    }
}
