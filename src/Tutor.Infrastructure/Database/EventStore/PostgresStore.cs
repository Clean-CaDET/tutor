using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;

namespace Tutor.Infrastructure.Database.EventStore
{
    public class PostgresStore : IEventStore
    {
        private readonly EventContext _eventContext;

        public PostgresStore(EventContext eventContext)
        {
            _eventContext = eventContext;
        }

        public IEnumerable<DomainEvent> GetEvents(DateTime? start, DateTime? end)
        {
            var min = start ?? DateTime.MinValue;
            var max = end ?? DateTime.MaxValue;
            return _eventContext.KcEvents.Where(
                e => e.KcEvent.TimeStamp > min && e.KcEvent.TimeStamp < max).Select(e => e.KcEvent).ToList();
        }

        public void Save(KnowledgeComponentMastery aggregate)
        {
            var eventsToSave = aggregate.GetChanges().Select(
                e => (KnowledgeComponentEvent)e).Select(e => new StoredKcEvent()
                {
                    AggregateId = aggregate.Id,
                    TimeStamp = e.TimeStamp,
                    LearnerId = e.LearnerId,
                    KnowledgeComponentId = e.KnowledgeComponentId,
                    KcEvent = e
                });
            _eventContext.KcEvents.AddRange(eventsToSave);
            _eventContext.SaveChanges();
            aggregate.ClearChanges();
        }
    }
}
