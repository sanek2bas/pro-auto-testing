using CRM.Database.Domain;
using Dapper;

namespace CRM.Database.Infrastructure;

public class UserRepository
{
    private readonly CrmContext context;

    public UserRepository(CrmContext context) 
    {
        this.context = context;
    }

    public User GetUserById(int userId)
    {
        User user = default;
        string readSql = 
            @"SELECT * FROM Users 
              WHERE id = @id";
        try
        {
            var connection = context.Connection;
            var users = connection.Query<User>(
                readSql, new { id = userId })
                .ToList();
            user = users.FirstOrDefault();
        }
        catch (Exception)
        {}
        return user;
    }

    public void SaveUser(User user)
    {
        string insertSql = 
            @"INSERT INTO Users (id, email, type) 
              VALUES (@id, @email, @type)";
        try
        {
            var connection = context.Connection;
            connection.Execute(insertSql, 
                new 
                {
                    id = user.UserId, 
                    email = user.Email, 
                    type = (int)user.Type
                });
        }
        catch (Exception)
        {
        }
    }
}
