using CRM.AppServices;

namespace CRM.IntegrationTests;

public sealed class BusSpy : IBus
{
    private List<string> sentMessages = new List<string>();


    public void Send(string message)
    {
        sentMessages.Add(message);
    }

    public BusSpy ShouldSendNumberOfMessages(int number)
    {
        Assert.Equal(number, sentMessages.Count);
        return this;
    }

    public BusSpy WithEmailChangedMessage(int userId, string newEmail)
    {
        string message = "Type: USER EMAIL CHANGED; " 
                        + $"Id: {userId}; " 
                        + $"NewEmail: {newEmail}";
        Assert.Contains(sentMessages, x => x == message);
        return this;
    }
}