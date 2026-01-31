namespace CRM;

public class UserController
{
    private readonly Database database = new Database();
    private readonly MessageBus messageBus = new MessageBus();

    public void ChangeEmail(int userId, string newEmail)
    {
        object[] data = database.GetUserById(userId);
        string email = (string)data[1];
        UserType type = (UserType)data[2];
        var user = new User(userId, email, type);
        
        object[] companyData = database.GetCompany();
        string companyDomainName = (string)companyData[0];
        int numberOfEmployees = (int)companyData[1];
        int newNumberOfEmployees = user.ChangeEmail(newEmail, companyDomainName, numberOfEmployees);
        
        database.SaveCompany(newNumberOfEmployees);
        database.SaveUser(user);
        
        messageBus.SendEmailChangedMessage(userId, newEmail);
    }
}

public class Database
{
    public object[] GetUserById(int userId)
    {
        //call db
        return new object[0];
    }

    public object[] GetCompany()
    {
        //call db
        return new object[0];
    }

    public void SaveUser(User user)
    {
        
    }

    public void SaveCompany(int numberOfEmployees)
    {}
}

public class MessageBus
{
    public void SendEmailChangedMessage(int userId, string email)
    {
        
    }
}