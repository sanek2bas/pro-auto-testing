namespace CRM.Domain;

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