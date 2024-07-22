using System.Linq.Expressions;
using System.Text.Json;
using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.LearningTasks.Core.Domain.EventSourcing;

public interface ILearningTaskEventQueryable
{
    ILearningTaskEventQueryable After(DateTime moment);
    ILearningTaskEventQueryable Before(DateTime moment);
    ILearningTaskEventQueryable Where(Expression<Func<JsonDocument, bool>> condition);
    List<DomainEvent> ToList();
    List<T> ToList<T>() where T : DomainEvent;
}