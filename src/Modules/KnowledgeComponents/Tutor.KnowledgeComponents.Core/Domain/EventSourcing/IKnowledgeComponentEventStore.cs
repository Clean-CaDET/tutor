using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.KnowledgeComponents.Core.Domain.EventSourcing;

public interface IKnowledgeComponentEventStore
{
    void Save(EventSourcedAggregateRoot aggregate);
    IKnowledgeComponentEventQueryable Events { get; }
    Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize);
}