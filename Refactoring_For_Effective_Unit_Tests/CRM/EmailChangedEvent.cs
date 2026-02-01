namespace CRM;

public class EmailChangedEvent
{
    public int UserId { get; }

    public string NewEmail { get; }
}