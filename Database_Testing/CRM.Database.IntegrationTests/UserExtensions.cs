using CRM.Database.Domain;

namespace CRM.Database.IntegrationTests;

public static class UserExtensions
{
    public static User ShouldExist(this User user)
    {
        Assert.NotNull(user);
        return user;
    }

    public static User WithEmail(this User user, string email)
    {
        Assert.Equal(email, user.Email);
        return user;
    }

    public static User WithType(this User user, UserType type)
    {
        Assert.Equal(type, user.Type);
        return user;
    }
}
