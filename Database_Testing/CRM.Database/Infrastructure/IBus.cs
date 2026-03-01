namespace CRM.Database.Infrastructure;

public interface IBus
{
    void Send(string message);
}
