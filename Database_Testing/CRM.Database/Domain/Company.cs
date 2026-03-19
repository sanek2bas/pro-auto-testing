namespace CRM.Database.Domain;

public class Company
{
    public int Id { get; }

    public string DomainName { get; }

    public int NumberOfEmployees { get; private set; }

    public Company(int id, string domain, int numbers)
    {
        Id = id;
        DomainName = domain;
        NumberOfEmployees = numbers;
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