using CRM.Database.Domain;

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
        User user = null;
        string sql = "SELECT * FROM Users WHERE id = @id";
        try
        {
            var cmd = context.Connection.CreateCommand();
            cmd.CommandText = sql;
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string email = reader.GetString(1);
                int type = reader.GetInt32(2);
                user = new User(id, email, (UserType)type);
                break;
            }
        }
        catch (Exception)
        {
        }

        return user;
    }

    public void SaveUser(User user)
    {
        return;
        //context.Users.Update(user);
    }
}
