using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.Postgres;

namespace Tutor.Courses.Infrastructure.Database.EventStore.Wallet;

public class StoredWalletDomainEvent : StoredDomainEvent
{
    public int LearnerId { get; set; }
    public int CourseId { get; set; }
}
