using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Infrastructure.Database.EventStore;

namespace Tutor.Infrastructure.Tests.TestData.EventStore
{
    public class EventQueryableTestCase
    {
        public IEnumerable<QueryParameter> QueryParameters { get; set; } = new List<QueryParameter>();

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

        public interface QueryParameter
        {
            public IEnumerable<DomainEvent> ApplyToEnumerable(IEnumerable<DomainEvent> events);
            public IEventQueryable ApplyToEventQueryable(IEventQueryable events);
        }

        public class AfterParameter : QueryParameter
        {
            public DateTime Moment { get; private set; }

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

        public class BeforeParameter : QueryParameter
        {
            public DateTime Moment { get; private set; }

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

        public class ConditionParameter : QueryParameter
        {
            public Expression<Func<JsonDocument, bool>> JsonCondition { get; private set; }
            public Func<dynamic, bool> DynamicCondition { get; private set; }

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
}
