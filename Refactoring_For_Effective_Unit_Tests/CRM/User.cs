namespace CRM;

public class User
{
    public int UserId { get; private set; }

    public string Email { get; private set; }

    public UserType Type { get; private set; }

    public User(int id, string email, UserType type)
    {
        UserId = id;
        Email = email;
        Type = type;
    }

    public void ChangeEmail(string newEmail, Company company)
    {
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
    }
}

public class UserFactory
{
    public static User Create(object[] data)
    {
        //Precondition.Requires(data.Length >= 3);
        if (data.Length < 3)
            throw new Exception();

        int id = (int)data[0];
        string email = (string)data[1];
        UserType type = (UserType)data[2];
        return new User(id, email, type);
    }
}