using System.Linq.Expressions;
using System.Text.Json;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.LearningTasks.Core.Domain.EventSourcing;

namespace Tutor.LearningTasks.Infrastructure.Database.EventStore.Postgres;

internal class PostgresEventQueryable : ILearningTaskEventQueryable
{
    private readonly ILearningTaskEventSerializer _serializer;

    private IQueryable<StoredDomainEvent> EventSource { get; init; }
    private IEnumerable<Expression<Func<JsonDocument, bool>>> Conditions { get; init; }

    public PostgresEventQueryable(IQueryable<StoredDomainEvent> eventSource, ILearningTaskEventSerializer serializer)
    {
        EventSource = eventSource;
        Conditions = new List<Expression<Func<JsonDocument, bool>>>();

        _serializer = serializer;
    }

    private PostgresEventQueryable(PostgresEventQueryable parent)
    {
        EventSource = parent.EventSource;
        Conditions = parent.Conditions;

        _serializer = parent._serializer;
    }

    public ILearningTaskEventQueryable After(DateTime moment)
    {
        return new PostgresEventQueryable(this)
        {
            EventSource = EventSource.Where(e => e.TimeStamp >= moment.ToUniversalTime())
        };
    }

    public ILearningTaskEventQueryable Before(DateTime moment)
    {
        return new PostgresEventQueryable(this)
        {
            EventSource = EventSource.Where(e => e.TimeStamp <= moment.ToUniversalTime())
        };
    }

    public ILearningTaskEventQueryable Where(Expression<Func<JsonDocument, bool>> condition)
    {
        return new PostgresEventQueryable(this)
        {
            Conditions = Conditions.Append(condition)
        };
    }

    public List<DomainEvent> ToList()
    {
        return ApplyConditions().ToList();
    }

    public List<T> ToList<T>() where T : DomainEvent
    {
        return ApplyConditions().OfType<T>().ToList();
    }

    private IEnumerable<DomainEvent> ApplyConditions()
    {
        IQueryable<JsonDocument> events = EventSource.Select(e => e.DomainEvent);
        foreach (Expression<Func<JsonDocument, bool>> condition in Conditions)
        {
            events = events.Where(condition);
        }

        return events.Select(e => _serializer.Deserialize(e));
    }
}