using System.Text.Json;
using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.KnowledgeComponents.Core.Domain.EventSourcing;

public interface IKnowledgeComponentEventSerializer
{
    JsonDocument Serialize(DomainEvent @event);
    DomainEvent Deserialize(JsonDocument @event);
}