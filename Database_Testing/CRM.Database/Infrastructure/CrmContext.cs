using CRM.Database.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRM.Database.Infrastructure;

public class CrmContext : DbContext
{
    public CrmContext(string connection)
    {

    }

    public DbSet<User> Users { get; set; }

    public DbSet<Company> Companies { get; set; }
}
