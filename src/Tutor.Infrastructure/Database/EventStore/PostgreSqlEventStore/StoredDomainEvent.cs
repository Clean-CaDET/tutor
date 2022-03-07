using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Database.EventStore.PostgreSqlEventStore
{
    internal class StoredDomainEvent
    {
        public int Id { get; set; }
        public string AggregateType { get; set; }
        public int AggregateId { get; set; }
        public DomainEvent DomainEvent { get; set; }
    }
}
