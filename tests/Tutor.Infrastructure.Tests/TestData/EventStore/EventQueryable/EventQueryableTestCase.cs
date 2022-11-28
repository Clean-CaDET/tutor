using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Tests.TestData.EventStore.EventQueryable;

public class EventQueryableTestCase
{
    public IEnumerable<IQueryParameter> QueryParameters { get; set; } = new List<IQueryParameter>();

    public IEventQueryable Execute(IEventQueryable queryable)
    {
        var random = new Random(Guid.NewGuid().GetHashCode());
        var parametersInRandomOrder = QueryParameters.OrderBy(_ => random.Next());

        var result = queryable;
        foreach (var parameter in parametersInRandomOrder)
            result = parameter.ApplyToEventQueryable(result);
        return result;
    }

    public IEnumerable<DomainEvent> GetExpectedResult(IEnumerable<DomainEvent> events)
    {
        var result = events;
        foreach (var parameter in QueryParameters)
            result = parameter.ApplyToEnumerable(result);
        return result;
    }

    public interface IQueryParameter
    {
        public IEnumerable<DomainEvent> ApplyToEnumerable(IEnumerable<DomainEvent> events);
        public IEventQueryable ApplyToEventQueryable(IEventQueryable events);
    }

    public class AfterParameter : IQueryParameter
    {
        public DateTime Moment { get; }

        public AfterParameter(DateTime moment)
        {
            Moment = moment;
        }

        public IEnumerable<DomainEvent> ApplyToEnumerable(IEnumerable<DomainEvent> events)
        {
            return events.Where(e => e.TimeStamp >= Moment);
        }

        public IEventQueryable ApplyToEventQueryable(IEventQueryable events)
        {
            return events.After(Moment);
        }
    }

    public class BeforeParameter : IQueryParameter
    {
        public DateTime Moment { get; }

        public BeforeParameter(DateTime moment)
        {
            Moment = moment;
        }

        public IEnumerable<DomainEvent> ApplyToEnumerable(IEnumerable<DomainEvent> events)
        {
            return events.Where(e => e.TimeStamp <= Moment);
        }

        public IEventQueryable ApplyToEventQueryable(IEventQueryable events)
        {
            return events.Before(Moment);
        }
    }

    public class ConditionParameter : IQueryParameter
    {
        public Expression<Func<JsonDocument, bool>> JsonCondition { get; }
        public Func<dynamic, bool> DynamicCondition { get; }

        public ConditionParameter(Expression<Func<JsonDocument, bool>> jsonCondition, Func<dynamic, bool> dynamicCondition)
        {
            JsonCondition = jsonCondition;
            DynamicCondition = dynamicCondition;
        }

        private bool SatisfiesCondition(DomainEvent @event)
        {
            try { return DynamicCondition.Invoke(@event); }
            catch (Exception) { return false; }
        }

        public IEnumerable<DomainEvent> ApplyToEnumerable(IEnumerable<DomainEvent> events)
        {
            return events.Where(SatisfiesCondition);
        }

        public IEventQueryable ApplyToEventQueryable(IEventQueryable events)
        {
            return events.Where(JsonCondition);
        }
    }
}