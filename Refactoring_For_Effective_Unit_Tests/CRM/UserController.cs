using CRM.AppServices;
using CRM.Domain;

namespace CRM;

public class UserController
{
    private readonly Database database;
    private readonly EventDispatcher eventDispatcher;

    public UserController(Database db, MessageBus bus, IDomainLogger logger)
    {
        database = db;
        eventDispatcher = new EventDispatcher(bus, logger);
    }

    public string ChangeEmail(int userId, string newEmail)
    {
        object[] userData = database.GetUserById(userId);
        var user = UserFactory.Create(userData);

        string error = user.CanChangeEmail();
        if (error != null)
            return error;
        
        object[] companyData = database.GetCompany();
        Company company = CompanyFactory.Create(companyData);

        user.ChangeEmail(newEmail, company);

        database.SaveCompany(company);
        database.SaveUser(user);

        eventDispatcher.Dispatch(user.DomainEvents);

        return "OK";
    }
}
