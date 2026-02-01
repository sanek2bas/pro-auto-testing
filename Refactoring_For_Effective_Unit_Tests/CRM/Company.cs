using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRM;

public class Company
{
    public string DomainName { get; private set; }

    public int NumberOfEmployees { get; private set; }

    public Company(string domain, int employess)
    {
        DomainName = domain;
        NumberOfEmployees = employess;
    }

    public void ChangeNumberOfEmployees(int delta)
    {
        //Precondition.Requires(NumberOfEmployees + delta >= 0);
        NumberOfEmployees += delta;
    }

    public bool IsEmailCorporate(string email)
    {
        string emailDomain = email.Split('@')[1];
        return emailDomain == DomainName;
    }
}

public class CompanyFactory
{
    public static Company Create(object[] companyData)
    {
        //Precondition.Requires(companyData.Length >= 2);
        if (companyData.Length < 2)
            throw new Exception();

        string companyDomainName = (string)companyData[0];
        int numberOfEmployees = (int)companyData[1];
        return new Company(companyDomainName, numberOfEmployees);
    }
}