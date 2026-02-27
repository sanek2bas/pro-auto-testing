namespace CRM.Database.Domain;

public interface IDomainEvent
{

}

public class EmailChangedEvent : IDomainEvent
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

public class UserTypeChangedEvent : IDomainEvent
{
    public int UserId { get; } 
    
    public UserType OldType { get; }

    public UserType NewType { get; }

    public UserTypeChangedEvent(int userId, UserType oldType, UserType newType)
    {
        UserId = userId;
        OldType = oldType;
        NewType = newType;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not UserTypeChangedEvent userTypeChangedEvent)
            return false;
        return
            userTypeChangedEvent.UserId == UserId
         && userTypeChangedEvent.OldType == OldType
         && userTypeChangedEvent.NewType == NewType;
    }
}