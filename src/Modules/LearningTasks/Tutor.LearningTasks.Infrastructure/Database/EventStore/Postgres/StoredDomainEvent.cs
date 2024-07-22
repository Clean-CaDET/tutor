using System.Text.Json;

namespace Tutor.LearningTasks.Infrastructure.Database.EventStore.Postgres;

internal class StoredDomainEvent
{
    public int Id { get; set; }
    public string AggregateType { get; set; }
    public int AggregateId { get; set; }
    public DateTime TimeStamp { get; set; }
    public JsonDocument DomainEvent { get; set; }
}