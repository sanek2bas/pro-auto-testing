using CRM.Database.Domain;

namespace CRM.Database.AppServices;

public class Database
{
    private readonly Dictionary<int, object[]> users;
    private readonly object[] companyData;

    public Database()
    {
        users = new Dictionary<int, object[]>();
        companyData = new object[2];
    }

    public object[] GetUserById(int userId)
    {
        object[] userData;
        users.TryGetValue(userId, out userData);
        return userData;
    }

    public object[] GetCompany()
    {
        return companyData;
    }

    public void SaveUser(User user)
    {
        var userData = new object[3]
        {
            user.UserId,
            user.Email,
            user.Type
        };
        users.Remove(user.UserId);
        users.Add(user.UserId, userData);
    }

    public void SaveCompany(Company company)
    {
        companyData[0] = company.DomainName;
        companyData[1] = company.NumberOfEmployees;
    }
}
