namespace LogAn.UnitTests;

public class FakeEmailService2 : IEmailService
{
    public string To { get; private set; }
    public string Subject { get; private set; }
    public string Body { get; private set; }

    public void SendEmail(string to, string subject, string body)
    {
        To = to;
        Subject = subject;
        Body = body;
    }
}
