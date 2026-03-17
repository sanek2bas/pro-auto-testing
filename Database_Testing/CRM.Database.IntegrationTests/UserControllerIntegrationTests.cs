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
        User user;

        using (var context = new CrmContext(ConnectionString))
        {
            var userRepository = new UserRepository(context);
            var companyRepository = new CompanyRepository(context);
            user = new User(0, "user@mycorp.com", UserType.Employee);
            userRepository.SaveUser(user);
            var company = new Company("mycorp.com", 1);
            companyRepository.SaveCompany(company);
            context.SaveChanges();

            var busSpy = new BusSpy();
            var messageBus = new MessageBus(busSpy);
            var loggerMock = new Mock<IDomainLogger>();
            var sut = new UserController(
                context, messageBus, loggerMock.Object);

            // Act
            string result = sut.ChangeEmail(user.UserId, "new@gmail.com");

            // Assert
            Assert.Equal("OK", result);

            User userFromDb = userRepository.GetUserById(user.UserId);
            Assert.Equal("new@gmail.com", userFromDb.Email);
            Assert.Equal(UserType.Customer, userFromDb.Type);

            Company companyFromDb = companyRepository.GetCompany();
            Assert.Equal(0, companyFromDb.NumberOfEmployees);

            busSpy.ShouldSendNumberOfMessages(1)
                .WithEmailChangedMessage(user.UserId, "new@gmail.com");
            loggerMock.Verify(x => x.UserTypeHasChanged(
                user.UserId, UserType.Employee, UserType.Customer), Times.Once);
        }
    }

    private User CreateUser(
        string email, UserType type, bool isEmailConfirmed)
    {
        using (var context = new CrmContext(ConnectionString))
        {
            var user = new User(0, email, type, isEmailConfirmed);
            var repository = new UserRepository(context);
            repository.SaveUser(user);
            context.SaveChanges();
            return user;
        }
    }
}