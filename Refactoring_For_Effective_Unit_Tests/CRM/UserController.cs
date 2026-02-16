using System.Security.AccessControl;

namespace CRM;

public class UserController
{
    private readonly Database database;
    private readonly IMessageBus messageBus;

    public UserController(Database db, IMessageBus bus)
    {
        database = db;
        messageBus = bus;
    }

    public string ChangeEmail(int userId, string newEmail)
    {
        object[] userData = database.GetUserById(userId);
        var user = UserFactory.Create(userData);
        
        object[] companyData = database.GetCompany();
        Company company = CompanyFactory.Create(companyData);

        user.ChangeEmail(newEmail, company);

        database.SaveCompany(company);
        database.SaveUser(user);

        foreach (var ev in user.EmailChangedEvents)
            messageBus.SendEmailChangedMessage(ev.UserId, ev.NewEmail);

        return "OK";
    }
}

public class Database
{
    private readonly Dictionary<int, object[]> users;
    private readonly object[] companyData;

    public Database()
    {
        users = new Dictionary<int, object[]>();
        companyData = new object[2];
    }

    public object[] GetUserById(int userId)
    {
        object[] userData;
        users.TryGetValue(userId, out userData);
        return userData;
    }

    public object[] GetCompany()
    {
        return companyData;
    }

    public void SaveUser(User user)
    {
        var userData = new object[3]
        {
            user.UserId,
            user.Email,
            user.Type
        };
        users.Remove(user.UserId);
        users.Add(user.UserId, userData);
    }

    public void SaveCompany(Company company)
    {
        companyData[0] = company.DomainName;
        companyData[1] = company.NumberOfEmployees;
    }
}

public interface IMessageBus
{
    void SendEmailChangedMessage(int userId, string email);
}

public class MessageBus : IMessageBus
{
    public void SendEmailChangedMessage(int userId, string email)
    {
        
    }
}