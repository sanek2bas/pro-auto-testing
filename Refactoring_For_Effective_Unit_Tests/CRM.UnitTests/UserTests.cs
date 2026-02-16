
namespace CRM.UnitTests;

public class UserTests
{
    [Fact]
    public void Changing_Email_From_Non_Corporate_To_Corporate()
    {
        var company = new Company("mycorp.com", 1);
        var sut = new User(1, "user@gmail.com", UserType.Customer);
        
        sut.ChangeEmail("new@mycorp.com", company);
        
        Assert.Equal(2, company.NumberOfEmployees);
        Assert.Equal("new@mycorp.com", sut.Email);
        Assert.Equal(UserType.Employee, sut.Type);
    }

    [Fact]
    public void Changing_Email_From_Corporate_To_Non_Corporate()
    {
        var company = new Company("mycorp.com", 1);
        var sut = new User(1, "user@mycorp.com", UserType.Employee);

        sut.ChangeEmail("new@gmail.com", company);

        Assert.Equal(0, company.NumberOfEmployees);
        Assert.Equal("new@gmail.com", sut.Email);
        Assert.Equal(UserType.Customer, sut.Type);
        Assert.Single(sut.EmailChangedEvents);
        Assert.Equal(new EmailChangedEvent(1, "new@gmail.com"), 
                     sut.EmailChangedEvents[0]);
    }

    [InlineData("mycorp.com", "email@mycorp.com", true)]
    [InlineData("mycorp.com", "email@gmail.com", false)]
    [Theory]
    public void Differentiates_A_Corporate_Email_From_Non_Corporate(
        string domain, string email, bool expectedResult)
    {
        var sut = new Company(domain, 0);
        bool isEmailCorporate = sut.IsEmailCorporate(email);
        Assert.Equal(expectedResult, isEmailCorporate);
    }

    [Fact]
    public void Changing_Email_Without_Changing_User_Type()
    {
        var company = new Company("mycorp.com", 1);
        var sut = new User(1, "user@mycorp.com", UserType.Employee);

        sut.ChangeEmail("newUser@mycorp.com", company);

        Assert.Equal(1, company.NumberOfEmployees);
        Assert.Equal("newUser@mycorp.com", sut.Email);
        Assert.Equal(UserType.Employee, sut.Type);
    }

    [Fact]
    public void Changing_Email_To_The_Same_One()
    {
        var company = new Company("mycorp.com", 1);
        var sut = new User(1, "user@mycorp.com", UserType.Employee);

        sut.ChangeEmail("user@mycorp.com", company);

        Assert.Equal(1, company.NumberOfEmployees);
        Assert.Equal("user@mycorp.com", sut.Email);
        Assert.Equal(UserType.Employee, sut.Type);
    }
}
