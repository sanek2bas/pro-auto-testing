using CRM.AppServices;

namespace CRM.Domain;

public class EventDispatcher
{
    private readonly IMessageBus messageBus;
    private readonly IDomainLogger domainLogger;

    public EventDispatcher(IMessageBus bus, IDomainLogger logger)
    {
        messageBus = bus;
        domainLogger = logger;
    }

    public void Dispatch(List<IDomainEvent> events)
    {
        foreach (IDomainEvent ev in events)
        {
            Dispatch(ev);
        }
    }

    private void Dispatch(IDomainEvent ev)
    {
        switch (ev)
        {
            case EmailChangedEvent emailChangedEvent:
                messageBus.SendEmailChangedMessage(
                    emailChangedEvent.UserId,
                    emailChangedEvent.NewEmail);
                break;
            case UserTypeChangedEvent userTypeChangedEvent:
                domainLogger.UserTypeHasChanged(
                    userTypeChangedEvent.UserId,
                    userTypeChangedEvent.OldType,
                    userTypeChangedEvent.NewType);
                break;
        }
    }
}
