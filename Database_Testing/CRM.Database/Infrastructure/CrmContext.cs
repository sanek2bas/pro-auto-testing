using Npgsql;

namespace CRM.Database.Infrastructure;

public class CrmContext(string connectionString) : IDisposable
{
    private readonly string connectionString = connectionString;
    private NpgsqlConnection? connection;

    public NpgsqlConnection Connection =>
        connection ??= new NpgsqlConnection(connectionString);

    public void Dispose()
    {
        connection?.Close();
    }
}
