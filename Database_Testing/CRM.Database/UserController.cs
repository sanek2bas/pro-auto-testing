using CRM.Database.AppServices;
using CRM.Database.Domain;
using CRM.Database.Infrastructure;

namespace CRM.Database;

public class UserController
{
    private readonly CrmContext context;
    private readonly UserRepository userRepository;
    private readonly CompanyRepository companyRepository;
    private readonly EventDispatcher eventDispatcher;

    public UserController(
        CrmContext context, 
        MessageBus bus, 
        IDomainLogger logger)
    {
        this.context = context;
        userRepository = new UserRepository(context);
        companyRepository = new CompanyRepository(context);
        eventDispatcher = new EventDispatcher(bus, logger);
    }

    public string ChangeEmail(int userId, string newEmail)
    {
        User user = userRepository.GetUserById(userId);

        string error = user.CanChangeEmail();
        if (error != null)
            return error;
        
        Company company = companyRepository.GetCompany();

        user.ChangeEmail(newEmail, company);

        companyRepository.SaveCompany(company);
        userRepository.SaveUser(user);
        eventDispatcher.Dispatch(user.DomainEvents);
        
        context.SaveChanges();
        return "OK";
    }
}
