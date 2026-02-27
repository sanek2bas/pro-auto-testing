using CRM.Database.Domain;
using CRM.Database.Infrastructure;

namespace CRM.Database.IntegrationTests;

public class UserControllerIntegrationTests
{
    private string ConnectionString = "conncetion data";

    [Fact]
    public void Changing_Email_From_Corporate_To_Non_Corporate()
    {
        using (var context = new CrmContext(ConnectionString))
        {
            // Arrange
            var userRepository = 
                new UserRepository(context);
            var companyRepository =
                new CompanyRepository(context);
            var user = new User(0, "user@mycorp.com", UserType.Employee, false);
            userRepository.SaveUser(user);
            var company = new Company("mycorp.com", 1);
            companyRepository.SaveCompany(company);
            context.SaveChanges();
        }
    }
}