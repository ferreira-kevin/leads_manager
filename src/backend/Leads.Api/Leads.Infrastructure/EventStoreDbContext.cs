using Leads.EventSourcing.Core;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infrastructure.EventStore
{
    public class EventStoreDbContext : DbContext
    {
        public EventStoreDbContext(DbContextOptions<EventStoreDbContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasKey(e => new { e.ModelId, e.ModelVersion });

            base.OnModelCreating(modelBuilder);
        }
    }
}
