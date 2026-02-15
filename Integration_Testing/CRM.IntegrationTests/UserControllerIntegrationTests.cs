using System.Data.Common;
using System.Runtime.CompilerServices;
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

        var messageBusMock = new Mock<IMessageBus>();
        var sut = new UserController(db, messageBusMock.Object);

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
        messageBusMock.Verify(
            x => x.SendEmailChangedMessage(user.UserId, "new@gmail.com"), Times.Once);
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
