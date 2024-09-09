using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.Postgres;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.Postgres;

public class StoredKcDomainEvent : StoredDomainEvent
{
    public int KnowledgeComponentId { get; set; }
    public int LearnerId { get; set; }
}