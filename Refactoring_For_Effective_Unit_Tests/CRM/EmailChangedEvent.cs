namespace CRM;

public class EmailChangedEvent
{
    public int UserId { get; }

    public string NewEmail { get; }

    public EmailChangedEvent(int userId, string email)
    {
        UserId = userId;
        NewEmail = email;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not EmailChangedEvent emailChangedEvent)
            return false;
        return 
            emailChangedEvent.UserId == UserId 
         && emailChangedEvent.NewEmail == NewEmail;
    }
}