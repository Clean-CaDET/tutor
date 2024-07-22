using System.Linq.Expressions;
using System.Text.Json;
using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.KnowledgeComponents.Core.Domain.EventSourcing;

public interface IKnowledgeComponentEventQueryable
{
    IKnowledgeComponentEventQueryable After(DateTime moment);
    IKnowledgeComponentEventQueryable Before(DateTime moment);
    IKnowledgeComponentEventQueryable Where(Expression<Func<JsonDocument, bool>> condition);
    List<DomainEvent> ToList();
    List<T> ToList<T>() where T : DomainEvent;
}