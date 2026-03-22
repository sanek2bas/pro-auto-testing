public class Logger
{
    private readonly bool isTestEnvironment;
    
    public Logger(bool isTestEnvironment)
    {
        this.isTestEnvironment = isTestEnvironment;
    }

    public void Log(string text)
    {
        if (isTestEnvironment) 
        return;
        /* Логирование текста */
    }
}