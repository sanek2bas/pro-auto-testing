using CRM.Database.Domain;

namespace CRM.Database.IntegrationTests;

public static class CompanyExtensions
{
    public static Company ShouldExist(this Company company)
    {
        Assert.NotNull(company);
        return company;
    }

    public static Company WithNumberOfEmployees(this Company company, int numberOfEmployees)
    {
        Assert.Equal(numberOfEmployees, company.NumberOfEmployees);
        return company;
    }
}