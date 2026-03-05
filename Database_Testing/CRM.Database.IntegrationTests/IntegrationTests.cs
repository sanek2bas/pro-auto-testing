using System.Data;
using System.Data.SqlClient;

namespace CRM.Database.IntegrationTests;

public abstract class IntegrationTests
{
    protected const string ConnectionString = "";

    private void ClearDatabase()
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
