using CRM.Database.AppServices;
using CRM.Database.Domain;
using CRM.Database.Infrastructure;
using Moq;

namespace CRM.Database.IntegrationTests;

public sealed class UserControllerIntegrationTests 
    : IntegrationTests
{
    public UserControllerIntegrationTests() 
        : base() {}
    
    [Fact]
    public void Changing_Email_From_Corporate_To_Non_Corporate()
    {
        //Arrange
        ClearDatabase();
        User user = CreateUser(
            id: 0,
            email: "user@mycorp.com", 
            type: UserType.Employee);
        CreateCompany(
            domain: "mycorp.com",
            numberOfEmployees: 1);
        
        var busSpy = new BusSpy();
        var messageBus = new MessageBus(busSpy);
        var loggerMock = new Mock<IDomainLogger>();

        //Act
        string result = Execute(
            x => x.ChangeEmail(user.UserId, "new@gmail.com"),
            messageBus,
            loggerMock.Object);

        // Assert
        Assert.Equal("OK", result);

        User userFromDb = QueryUser(user.UserId);
        userFromDb.ShouldExist()
                  .WithEmail("new@gmail.com")
                  .WithType(UserType.Customer);
        //Assert.Equal("new@gmail.com", userFromDb.Email);
        //Assert.Equal(UserType.Customer, userFromDb.Type);

        Company companyFromDb = QueryCompany();
        companyFromDb.ShouldExist()
                     .WithNumberOfEmployees(0);
        //Assert.Equal(0, companyFromDb.NumberOfEmployees);

        busSpy.ShouldSendNumberOfMessages(1)
              .WithEmailChangedMessage(user.UserId, "new@gmail.com");
        loggerMock.Verify(x => x.UserTypeHasChanged(
            user.UserId, UserType.Employee, UserType.Customer), Times.Once);
    }

    private User CreateUser(
        int id, string email, UserType type)
    {
        using var context = new CrmContext(ConnectionString);
        {
            var user = new User(id, email, type);
            var repository = new UserRepository(context);
            repository.SaveUser(user);
            return user;
        }
    }

    private User QueryUser(int userId)
    {
        using (var context = new CrmContext(ConnectionString))
        {
            var userRepository = new UserRepository(context);
            User user = userRepository.GetUserById(userId);
            return user;
        }
    }

    private void CreateCompany(
        string domain, int numberOfEmployees)
    {
        using (var context = new CrmContext(ConnectionString))
        {
            var companyRepository = new CompanyRepository(context);
            var company = new Company(0, "mycorp.com", 1);
            companyRepository.SaveCompany(company);
        }
    }

    private Company QueryCompany()
    {
        using (var context = new CrmContext(ConnectionString))
        {
            var companyRepository = new CompanyRepository(context);
            Company company = companyRepository.GetCompany();
            return company;
        }
    }

    private string Execute(
        Func<UserController, string> func,
        MessageBus messageBus, 
        IDomainLogger logger)
    {
        using (var context = new CrmContext(ConnectionString))
        {
            var controller = 
                new UserController(context, messageBus, logger);
            return func(controller);
        }
    }
}