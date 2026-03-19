using CRM.Database.Domain;
using Dapper;

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
        Company company = default;
        string readSql =
            @"SELECT * FROM Company";
        try
        {
            var connection = context.Connection;
            var companies = connection.Query<Company>(
                readSql).ToList();
            company = companies.FirstOrDefault();

        }
        catch (Exception)
        {}
        return company;
    }

    public void SaveCompany(Company company)
    {
        string insertSql =
            @"INSERT INTO Company (id, domain, numbers) 
              VALUES (0, @domain, @numbers)
              ON CONFLICT (id) DO UPDATE SET 
              (domain, numbers) = (EXCLUDED.domain, EXCLUDED.numbers)";
        try
        {
            var connection = context.Connection;
            connection.Execute(insertSql,
                new
                {
                    domain = company.DomainName,
                    numbers = company.NumberOfEmployees
                });
        }
        catch (Exception)
        {
        }
    }
}