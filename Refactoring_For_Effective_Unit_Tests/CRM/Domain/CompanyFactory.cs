namespace CRM.Domain;

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