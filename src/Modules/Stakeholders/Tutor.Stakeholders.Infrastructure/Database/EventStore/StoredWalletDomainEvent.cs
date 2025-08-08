using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.Postgres;

namespace Tutor.Stakeholders.Infrastructure.Database.EventStore;

public class StoredWalletDomainEvent : StoredDomainEvent
{
    public int LearnerId { get; set; }
}