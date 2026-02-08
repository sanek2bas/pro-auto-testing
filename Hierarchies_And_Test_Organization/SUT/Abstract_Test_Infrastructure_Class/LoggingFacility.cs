namespace SUT.Abstract_Test_Infrastructure_Class;

public interface ILogger
{
    void Log(string text);
}

public class LoggingFacility
{
    public static void Log(string text)
    {
        Logger.Log(text);       
    }
    public static ILogger Logger { get; set; }
}