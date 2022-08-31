using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Tests.TestData.EventStore
{
    public class Query
    {
        public class ConditionParameter
        {
            public Expression<Func<JsonDocument, bool>> JsonCondition { get; set; }
            public Func<dynamic, bool> DynamicCondition { get; set; }

            public ConditionParameter(Expression<Func<JsonDocument, bool>> jsonCondition, Func<dynamic, bool> dynamicCondition)
            {
                JsonCondition = jsonCondition;
                DynamicCondition = dynamicCondition;
            }

            public bool Evaluate(DomainEvent @event)
            {
                try { return DynamicCondition.Invoke(@event); }
                catch (Exception) { return false; }
            }
        }

        public IEnumerable<DateTime> AfterParameters { get; set; } = new List<DateTime>();
        public IEnumerable<DateTime> BeforeParameters { get; set; } = new List<DateTime>();
        public IEnumerable<ConditionParameter> ConditionParameters { get; set; } = new List<ConditionParameter>();

        public IEnumerable<DomainEvent> GetExpectedResult(IEnumerable<DomainEvent> events)
        {
            var result = events;
            foreach (var moment in AfterParameters) result = result.Where(e => e.TimeStamp >= moment);
            foreach (var moment in BeforeParameters) result = result.Where(e => e.TimeStamp <= moment);
            foreach (var condition in ConditionParameters) result = result.Where(e => condition.Evaluate(e));
            return result;
        }
    }

}
