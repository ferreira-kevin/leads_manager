using Leads.EventSourcing.Core;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infrastructure.EventStore
{
    public class EFEventStore : IEventStore
    {
        private readonly EventStoreDbContext _context;

        public EFEventStore(EventStoreDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Event @event)
        {
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Event>> GetEventsByModelIdAsync(Guid modelId)
        {
            return await _context.Events
                .Where(e => e.ModelId == modelId)
                .OrderBy(e => e.ModelVersion)
                .ToListAsync();
        }
    }
}
