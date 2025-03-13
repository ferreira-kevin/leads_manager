//using Leads.EventSourcing.Core;
//using Leads.Infrastructure.EventStore;
//using Leads.Infrastructure.ReadModel;
//using System.Text.Json;

//namespace Leads.Infrastructure.Repositories
//{
//    public class LeadRepository
//    {
//        private readonly IEventStore _eventStore;
//        private readonly LeadProjector _projector;

//        public LeadRepository(IEventStore eventStore, LeadProjector projector)
//        {
//            _eventStore = eventStore;
//            _projector = projector;
//        }

//        public async Task SaveAsync(LeadAggregate aggregate)
//        {
//            int version = 1;

//            foreach (var @event in aggregate.UncommittedEvents)
//            {
//                var eventType = @event.GetType().Name;
//                var eventData = JsonSerializer.Serialize(@event);

//                var storedEvent = Event.Create(aggregate.Id, version++, eventType, DateTime.UtcNow, eventData);

//                await _eventStore.SaveAsync(storedEvent);
//                await _projector.ProjectAsync(@event);
//            }

//            aggregate.MarkEventsAsCommitted();
//        }

//        public async Task<LeadAggregate?> GetByIdAsync(Guid id)
//        {
//            var events = await _eventStore.GetEventsByModelIdAsync(id);
//            if (events == null || events.Count == 0)
//                return null;

//            var aggregate = (LeadAggregate)Activator.CreateInstance(typeof(LeadAggregate), true)!;

//            foreach (var storedEvent in events)
//            {
//                var eventType = Type.GetType($"Leads.Domain.Events.{storedEvent.Type}");
//                if (eventType == null) continue;

//                var @event = JsonSerializer.Deserialize(storedEvent.Data, eventType);
//                if (@event != null)
//                    aggregate.Apply(@event);
//            }

//            return aggregate;
//        }
//    }
//}
