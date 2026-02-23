using CRM.Infrastructure;

namespace CRM.Domain;

public class User
{
    public int UserId { get; private set; }

    public string Email { get; private set; }

    public UserType Type { get; private set; }

    public bool IsEmailConfirmed { get; private set; }

    public List<EmailChangedEvent> EmailChangedEvents { get; private set; }

    public User(int id, string email, UserType type)
    {
        UserId = id;
        Email = email;
        Type = type;
        EmailChangedEvents = new List<EmailChangedEvent>();
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
        }

        Email = newEmail;
        Type = newType;

        EmailChangedEvents.Add(new EmailChangedEvent(UserId, newEmail));
    }

    public string CanChangeEmail()
    {
        if (IsEmailConfirmed)
            return "Can't change a confirmed email";
        return null;
    }
}