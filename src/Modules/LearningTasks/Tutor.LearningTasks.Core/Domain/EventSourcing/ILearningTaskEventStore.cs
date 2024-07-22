using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.LearningTasks.Core.Domain.EventSourcing;

public interface ILearningTaskEventStore
{
    void Save(EventSourcedAggregateRoot aggregate);
    ILearningTaskEventQueryable Events { get; }
    Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize);
}