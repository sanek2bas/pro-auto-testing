namespace CRM;

public class UserController
{
    private readonly Database database = new Database();
    private readonly MessageBus messageBus = new MessageBus();

    public void ChangeEmail(int userId, string newEmail)
    {
        object[] userData = database.GetUserById(userId);
        var user = UserFactory.Create(userData);
        
        object[] companyData = database.GetCompany();
        Company company = CompanyFactory.Create(companyData);
        
        database.SaveCompany(company);
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

    public void SaveCompany(Company company)
    {}
}

public class MessageBus
{
    public void SendEmailChangedMessage(int userId, string email)
    {
        
    }
}