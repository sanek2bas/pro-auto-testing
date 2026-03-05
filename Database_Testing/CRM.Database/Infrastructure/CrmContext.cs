using CRM.Database.Domain;
using Npgsql;

namespace CRM.Database.Infrastructure;

public class CrmContext : IDisposable
{
    private readonly NpgsqlConnection connection;

    public CrmContext(string connectionString)
    {
        connection = 
            new NpgsqlConnection(connectionString);
    }

    //public IList<User> Users { get; set; }

    //public IList<Company> Companies { get; set; }

    public void Dispose()
    {
        connection.Close();
    }
}
