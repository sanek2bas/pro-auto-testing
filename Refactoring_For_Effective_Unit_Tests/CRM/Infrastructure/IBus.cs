namespace CRM.Infrastructure;

public interface IBus
{
    void Send(string message);
}
