using CRM.AppServices;
using CRM.Domain;

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
