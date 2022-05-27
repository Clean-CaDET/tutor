using System.Collections.Generic;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;

namespace Tutor.Infrastructure.Database.EventStore
{
    public interface IEventStore
    {
        void Save(EventSourcedAggregateRoot aggregate);
        IEventQueryable Events { get; }
        Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize);
        List<KnowledgeComponentEvent> GetKcEvents(List<int> kcIds, List<int> learnerIds);
    }
}
