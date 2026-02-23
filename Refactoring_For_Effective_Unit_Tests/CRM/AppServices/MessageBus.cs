namespace CRM.AppServices;

public interface IMessageBus
{
    void SendEmailChangedMessage(int userId, string email);
}

public class MessageBus : IMessageBus
{
    public void SendEmailChangedMessage(int userId, string email)
    {

    }
}
