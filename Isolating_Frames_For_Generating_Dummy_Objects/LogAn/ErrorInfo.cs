namespace LogAn;

public class ErrorInfo
{
    public int Severity { get; private set; }

    public string Message { get; private set; }

    public ErrorInfo(int severity, string message)
    {
        Severity = severity;
        Message = message;
    }

    public override bool Equals(object? obj)
    {
        if(obj is not ErrorInfo errorInfo)
            return false;
        
        if(ReferenceEquals(this, errorInfo))
            return true;

        return Severity == errorInfo.Severity
            && Message == errorInfo.Message;
    }
}
