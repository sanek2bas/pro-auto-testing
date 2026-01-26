namespace LogAn;

public class LogAnalyzer
{
    private readonly ILogger logger;
    
    public int MinNameLength { get; set; }

    public LogAnalyzer(ILogger logger)
    {
        this.logger = logger;
    }

    public void Analyze(string fileName)
    {
        if (fileName.Length < MinNameLength)
            logger.LogError("The name is too short");
    }
}
