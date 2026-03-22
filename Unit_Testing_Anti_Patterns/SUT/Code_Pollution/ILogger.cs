public interface ILogger
{
    void Log(string text);
}

public class Logger2 : ILogger
{
    public void Log(string text)
    {
        /* Логирование текста */
    }
}

public class FakeLogger2 : ILogger
{
    public void Log(string text)
    {
        /* Ничего не происходит */
    }
}