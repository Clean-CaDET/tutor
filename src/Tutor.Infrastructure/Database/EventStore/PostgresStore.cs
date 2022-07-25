using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;

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

            var events = _eventContext.Events.
                Where(e => EF.Functions.JsonExistAll(e.DomainEvent, "KnowledgeComponentId", "LearnerId") 
                            && kcIds.Contains(e.DomainEvent.RootElement.GetProperty("KnowledgeComponentId").GetInt32())
                            && learnerIds.Contains(e.DomainEvent.RootElement.GetProperty("LearnerId").GetInt32()));

            return events.Select(e => _eventSerializer.Deserialize(e.DomainEvent) as KnowledgeComponentEvent).ToList();
        }

        public List<DomainEvent> GetAllEvents()
        {
            return _eventContext.Events.Select(e => _eventSerializer.Deserialize(e.DomainEvent)).ToList();
        }

        private List<KnowledgeComponentEvent> GetAllKcEvents(List<int> kcIds)
        {
            var events = _eventContext.Events.
                Where(e => EF.Functions.JsonExistAll(e.DomainEvent, "KnowledgeComponentId")
                            && kcIds.Contains(e.DomainEvent.RootElement.GetProperty("KnowledgeComponentId").GetInt32()));

            return events.Select(e => _eventSerializer.Deserialize(e.DomainEvent) as KnowledgeComponentEvent).ToList();
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
