using System;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;

namespace Tutor.Infrastructure.Database.EventStore
{
    public class StoredKcEvent
    {
        public int Id { get; set; }
        public int AggregateId { get; set; }
        public int KnowledgeComponentId { get; set; }
        public int LearnerId { get; set; }
        public DateTime TimeStamp { get; set; }
        public KnowledgeComponentEvent KcEvent { get; set; }
    }
}
