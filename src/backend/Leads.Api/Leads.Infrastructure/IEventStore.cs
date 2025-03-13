using Leads.EventSourcing.Core;

namespace Leads.Infrastructure.EventStore
{
    public interface IEventStore
    {
        Task SaveAsync(Event @event);
        Task<List<Event>> GetEventsByModelIdAsync(Guid modelId);
    }
}
