using CRM.AppServices;
using CRM.AppServices.DB;
using CRM.Domain;
using CRM.Infrastructure;
using Moq;

namespace CRM.IntegrationTests;

public class UserControllerIntegrationTests
{
    [Fact]
    public void Change_Email_From_Corporate_To_Non_Corporate()
    {
        var db = new Database();
        User user = CreateUser("user@mycorp.com", UserType.Employee, db);
        _ = CreateCompany("mycorp.com", 1, db);

        var busMock = new Mock<IBus>();
        var messagBus = new MessageBus(busMock.Object);
        var loggerMock = new Mock<IDomainLogger>();
        var sut = new UserController(db, messagBus, loggerMock.Object);

        // Act
        string result = sut.ChangeEmail(user.UserId, "new@gmail.com");
        // Assert
        Assert.Equal("OK", result);

        object[] userData = db.GetUserById(user.UserId);
        User userFromDb = UserFactory.Create(userData);
        Assert.Equal("new@gmail.com", userFromDb.Email);
        Assert.Equal(UserType.Customer, userFromDb.Type);

        object[] companyData = db.GetCompany();
        Company companyFromDb = CompanyFactory.Create(companyData);
        Assert.Equal(0, companyFromDb.NumberOfEmployees);

        //Check interactions with mocks
        busMock.Verify(
            x => x.Send("Type: USER EMAIL CHANGED; " 
                      + $"Id: {user.UserId}; "
                      + "NewEmail: new@gmail.com"));
        loggerMock.Verify(
            x => x.UserTypeHasChanged(user.UserId, UserType.Employee, UserType.Customer));
    }

    [Fact]
    public void Change_Email_From_Corporate_To_Non_Corporate_UsingSpy()
    {
        var db = new Database();
        User user = CreateUser("user@mycorp.com", UserType.Employee, db);
        _ = CreateCompany("mycorp.com", 1, db);

        var busSpy = new BusSpy();
        var messagBus = new MessageBus(busSpy);
        var loggerMock = new Mock<IDomainLogger>();
        var sut = new UserController(db, messagBus, loggerMock.Object);

        // Act
        string result = sut.ChangeEmail(user.UserId, "new@gmail.com");
        // Assert
        Assert.Equal("OK", result);

        object[] userData = db.GetUserById(user.UserId);
        User userFromDb = UserFactory.Create(userData);
        Assert.Equal("new@gmail.com", userFromDb.Email);
        Assert.Equal(UserType.Customer, userFromDb.Type);

        object[] companyData = db.GetCompany();
        Company companyFromDb = CompanyFactory.Create(companyData);
        Assert.Equal(0, companyFromDb.NumberOfEmployees);

        //Check interactions
        busSpy.ShouldSendNumberOfMessages(1)
              .WithEmailChangedMessage(user.UserId, "new@gmail.com");
        loggerMock.Verify(
            x => x.UserTypeHasChanged(user.UserId, UserType.Employee, UserType.Customer));
    }

    private User CreateUser(string email, UserType userType, Database db)
    {
        var user = new User(1, email, userType);
        db.SaveUser(user);
        return user;
    } 

    private Company CreateCompany(string domain, int employess, Database db)
    {
        var company = new Company(domain, employess);
        db.SaveCompany(company);
        return company;
    } 
}
