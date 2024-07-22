using System.Text.Json;
using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.LearningTasks.Core.Domain.EventSourcing;

public interface ILearningTaskEventSerializer
{
    JsonDocument Serialize(DomainEvent @event);
    DomainEvent Deserialize(JsonDocument @event);
}