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
        return context.Users
        .FirstOrDefault(x => x.UserId == userId);
    }

    public void SaveUser(User user)
    {
        context.Users.Update(user);
    }
}
