using Npgsql;

namespace CRM.Database.IntegrationTests;

public abstract class IntegrationTests
{
    protected string ConnectionString = 
        "Host=localhost;Port=8080;Username=postgres;Password=postgres;Database=crm";

    protected IntegrationTests()
    {
        CreateDatabase();
    }

    protected void ClearDatabase()
    {
        string deleteSql = @"
            DELETE FROM User;
            DELETE FROM Company;";
        
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        using var deleteCmd = new NpgsqlCommand(deleteSql);
        deleteCmd.ExecuteNonQuery();

        conn.Close();
        
    }
    
    private void CreateDatabase()
    {
        string createTableUserSql = @"
            DROP TABLE IF EXISTS User;
            CREATE TABLE Users(
                id INT PRIMARY KEY,
                email VARCHAR(100),
                type INT);";
        string createTableCompanySql = @"
            DROP TABLE IF EXISTS Company;
            CREATE TABLE Company(
                id INT PRIMARY KEY, 
                domain VARCHAR(100),
                numbers INT);";

        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        using var userTableCmd = new NpgsqlCommand(createTableUserSql);
        userTableCmd.ExecuteNonQuery();

        using var companyTableCmd = new NpgsqlCommand(createTableCompanySql);
        companyTableCmd.ExecuteNonQuery();

        conn.Close();
    }
}
