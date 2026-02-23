namespace CRM.AppServices;

public interface IBus
{
    void Send(string message);
}

//public interface IMessageBus
//{
//    void SendEmailChangedMessage(int userId, string email);
//}

//public class MessageBus : IMessageBus
public class MessageBus
{
    private readonly IBus bus;

    public MessageBus(IBus bus)
    {
        this.bus = bus;
    }

    public void SendEmailChangedMessage(int userId, string newEmail)
    {
        bus.Send("Type: USER EMAIL CHANGED; " 
                + $"Id: {userId}; " 
                + $"NewEmail: {newEmail}");
    }
}
