using System.Text.Json;

namespace Tutor.BuildingBlocks.Infrastructure.Database.EventStore.Postgres;

public class StoredDomainEvent
{
    public int Id { get; set; }
    public string AggregateType { get; set; }
    public int AggregateId { get; set; }
    public DateTime TimeStamp { get; set; }
    public JsonDocument DomainEvent { get; set; }
}