using Npgsql;
using System.Reflection.Emit;

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
            DELETE FROM Users;
            DELETE FROM Company;";
        
        using var connection = 
            new NpgsqlConnection(ConnectionString);
        using var deleteCmd = 
            new NpgsqlCommand(deleteSql, connection);
        
        connection.Open();
        
        deleteCmd.ExecuteNonQuery();

        connection.Close();        
    }
    
    private void CreateDatabase()
    {
        string createTableUsersSql = @"
            DROP TABLE IF EXISTS Users;
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

        using var connection = 
            new NpgsqlConnection(ConnectionString);
        using var usersTableCmd = 
            new NpgsqlCommand(createTableUsersSql, connection);
        using var companyTableCmd = 
            new NpgsqlCommand(createTableCompanySql, connection);
        
        connection.Open();

        usersTableCmd.ExecuteNonQuery();        
        companyTableCmd.ExecuteNonQuery();

        connection.Close();
    }
}
