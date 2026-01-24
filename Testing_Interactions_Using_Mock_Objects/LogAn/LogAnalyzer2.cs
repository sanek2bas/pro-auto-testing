using System.Xml.Linq;

namespace LogAn;

public class LogAnalyzer2
{
    public LogAnalyzer2(IWebService service, IEmailService email)
    {
        Service = service;
        Email = email;
    }

    public IWebService Service { get; set; }

    public IEmailService Email { get; set; }

    public void Analyze(string fileName)
    {
        if (fileName.Length < 8)
        {
            try
            {
                Service.LogError($"File name is too short {fileName}");
            }
            catch (Exception e)
            {
                Email.SendEmail(
                    "someone@somewhere.com", 
                    "can't log", 
                    e.Message);
            }
        }
    }
}

