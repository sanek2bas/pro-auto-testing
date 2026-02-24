using CRM.Domain;

namespace CRM.Infrastructure;

public interface IDomainLogger
{
    void UserTypeHasChanged(int userId, UserType oldType, UserType newType);
}

public class DomainLogger : IDomainLogger
{
    private readonly ILogger logger;

    public DomainLogger(ILogger logger)
    {
        this.logger = logger;
    }

    public void UserTypeHasChanged(
        int userId, UserType oldType, UserType newType)
    {
        logger.Info(
            $"User {userId} changed type " +
            $"from {oldType} to {newType}");
    }
}
