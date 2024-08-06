using System.Linq.Expressions;
using System.Text.Json;
using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.BuildingBlocks.Core.Domain.EventSourcing;

public interface IEventQueryable<TEvent> where TEvent : DomainEvent
{
    IEventQueryable<TEvent> After(DateTime moment);
    IEventQueryable<TEvent> Before(DateTime moment);
    IEventQueryable<TEvent> Where(Expression<Func<JsonDocument, bool>> condition);
    List<TEvent> ToList();
    List<T> ToList<T>() where T : TEvent;
}
