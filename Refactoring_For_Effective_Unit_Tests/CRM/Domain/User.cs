namespace CRM.Domain;

public class User
{
    public int UserId { get; private set; }

    public string Email { get; private set; }

    public UserType Type { get; private set; }

    public bool IsEmailConfirmed { get; private set; }

    public List<IDomainEvent> DomainEvents { get; private set; }

    public User(int id, string email, UserType type)
    {
        UserId = id;
        Email = email;
        Type = type;
        DomainEvents = new List<IDomainEvent>();
    }

    public void ChangeEmail(string newEmail, Company company)
    {
        //Precondition.Requires(CanChangeEmail() == null);

        if (Email == newEmail)
            return;

        UserType newType = company.IsEmailCorporate(newEmail)
            ? UserType.Employee
            : UserType.Customer;
        
        if (Type != newType)
        {
            int delta = newType == UserType.Employee ? 1 : -1;
            company.ChangeNumberOfEmployees(delta);
            AddDomainEvent(new UserTypeChangedEvent(UserId, Type, newType));
        }

        Email = newEmail;
        Type = newType;

        AddDomainEvent(new EmailChangedEvent(UserId, newEmail));
    }

    public string CanChangeEmail()
    {
        if (IsEmailConfirmed)
            return "Can't change a confirmed email";
        return null;
    }

    private void AddDomainEvent(IDomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }
}