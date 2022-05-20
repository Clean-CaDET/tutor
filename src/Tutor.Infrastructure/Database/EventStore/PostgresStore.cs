using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;
using Tutor.Infrastructure.Serialization;

namespace Tutor.Infrastructure.Database.EventStore
{
    public class PostgresStore : IEventStore
    {
        private readonly EventContext _eventContext;
        private readonly IEventSerializer _eventSerializer;

        public PostgresStore(EventContext eventContext, IEventSerializer eventSerializer)
        {
            _eventContext = eventContext;
            _eventSerializer = eventSerializer;
        }

        public async Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize)
        {
            var storedEvents = await _eventContext.Events
                .GetPaged(page, pageSize);

            return new PagedResult<DomainEvent>(
                storedEvents.Results.Select(e => _eventSerializer.Deserialize(e.DomainEvent)).ToList(),
                storedEvents.TotalCount);
        }

        public List<KnowledgeComponentEvent> GetKcEvents(List<int> kcIds, List<int> learnerIds)
        {
            if (learnerIds == null) return GetAllKcEvents(kcIds);
            // Should be refactored to send a better query to the DB. Also a better name for these methods.
            var allEvents = _eventContext.Events
                .Select(e => _eventSerializer.Deserialize(e.DomainEvent) as KnowledgeComponentEvent).ToList();

            return allEvents.Where(e => learnerIds.Contains(e.LearnerId)
                            && kcIds.Contains(e.KnowledgeComponentId)).ToList();
        }

        private List<KnowledgeComponentEvent> GetAllKcEvents(List<int> kcIds)
        {
            var allEvents = _eventContext.Events
                .Select(e => _eventSerializer.Deserialize(e.DomainEvent) as KnowledgeComponentEvent).ToList();

            return allEvents.Where(e => kcIds.Contains(e.KnowledgeComponentId)).ToList();
        }

        public void Save(EventSourcedAggregateRoot aggregate)
        {
            // class name is temporarily used as aggregate type until we choose a better approach
            var aggregateType = aggregate.GetType().Name;

            var eventsToSave = aggregate.GetChanges().Select(
                e => new StoredDomainEvent()
                {
                    AggregateType = aggregateType,
                    AggregateId = aggregate.Id,
                    TimeStamp = e.TimeStamp,
                    DomainEvent = _eventSerializer.Serialize(e)
                });
            _eventContext.Events.AddRange(eventsToSave);
            _eventContext.SaveChanges();
            aggregate.ClearChanges();
        }
    }
}
