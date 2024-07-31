using System.Linq.Expressions;
using System.Text.Json;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.Postgres;

internal class PostgresEventQueryable<TEvent> : IEventQueryable<TEvent> where TEvent : DomainEvent
{
    private readonly IEventSerializer<TEvent> _serializer;

    private IQueryable<StoredDomainEvent> EventSource { get; init; }
    private IEnumerable<Expression<Func<JsonDocument, bool>>> Conditions { get; init; }

    public PostgresEventQueryable(IQueryable<StoredDomainEvent> eventSource, IEventSerializer<TEvent> serializer)
    {
        EventSource = eventSource;
        Conditions = new List<Expression<Func<JsonDocument, bool>>>();

        _serializer = serializer;
    }

    private PostgresEventQueryable(PostgresEventQueryable<TEvent> parent)
    {
        EventSource = parent.EventSource;
        Conditions = parent.Conditions;

        _serializer = parent._serializer;
    }

    public IEventQueryable<TEvent> After(DateTime moment)
    {
        return new PostgresEventQueryable<TEvent>(this)
        {
            EventSource = EventSource.Where(e => e.TimeStamp >= moment.ToUniversalTime())
        };
    }

    public IEventQueryable<TEvent> Before(DateTime moment)
    {
        return new PostgresEventQueryable<TEvent>(this)
        {
            EventSource = EventSource.Where(e => e.TimeStamp <= moment.ToUniversalTime())
        };
    }

    public IEventQueryable<TEvent> Where(Expression<Func<JsonDocument, bool>> condition)
    {
        return new PostgresEventQueryable<TEvent>(this)
        {
            Conditions = Conditions.Append(condition)
        };
    }

    public List<TEvent> ToList()
    {
        return ApplyConditions().ToList();
    }

    public List<T> ToList<T>() where T : TEvent
    {
        return ApplyConditions().OfType<T>().ToList();
    }

    private IEnumerable<TEvent> ApplyConditions()
    {
        IQueryable<JsonDocument> events = EventSource.Select(e => e.DomainEvent);
        foreach (Expression<Func<JsonDocument, bool>> condition in Conditions)
        {
            events = events.Where(condition);
        }

        return events.Select(e => _serializer.Deserialize(e));
    }
}