using System.Data;
using System.Data.SqlClient;

namespace CRM.Database.IntegrationTests;

public abstract class IntegrationTests
{
    protected string ConnectionString = 
        "Host=localhost;Port=8080;Username=postgres;Password=postgres;Database=crm";

    protected void ClearDatabase()
    {
        string query =
            "DELETE FROM dbo.[User];" +
            "DELETE FROM dbo.Company;";
        
        using (var connection = new SqlConnection(ConnectionString))
        {
            var command = new SqlCommand(query, connection)
            {
                CommandType = CommandType.Text
            };
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
