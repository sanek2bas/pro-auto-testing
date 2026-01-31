
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
}
