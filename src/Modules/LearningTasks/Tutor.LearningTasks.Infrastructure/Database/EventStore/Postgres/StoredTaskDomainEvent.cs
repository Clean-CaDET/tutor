using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.Postgres;

namespace Tutor.LearningTasks.Infrastructure.Database.EventStore.Postgres;

public class StoredTaskDomainEvent : StoredDomainEvent
{
    public int LearnerId { get; set; }
    public int TaskId { get; set; }
}