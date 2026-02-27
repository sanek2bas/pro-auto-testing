using CRM.Database.Domain;

namespace CRM.Database.Infrastructure;

public class CompanyRepository
{
    private readonly CrmContext context;

    public CompanyRepository(CrmContext context)
    {
        this.context = context;
    }

    public Company GetCompany()
    {
        return context.Companies.FirstOrDefault();
    }

    public void SaveCompany(Company company)
    {
        context.Companies.Update(company);
    }
}