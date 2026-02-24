using CRM.AppServices;
using CRM.Domain;

namespace CRM.Infrastructure;

public class EventDispatcher
{
    private readonly MessageBus messageBus;
    private readonly IDomainLogger domainLogger;

    public EventDispatcher(MessageBus bus, IDomainLogger logger)
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
