using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.EventSourcing;
using static Tutor.Infrastructure.Tests.TestData.EventStore.Query;

namespace Tutor.Infrastructure.Tests.TestData.EventStore
{
    public static class QueryTestData
    {
        private static ICollection<object[]> _queries = new List<object[]>();

        public static IEnumerable<object[]> GetQueries()
        {
            if (_queries.Count == 0)
            {
                var queries = QueryBuilder.BuildAllPossibleQueries(_afterParameters, _beforeParameters, _conditionParameters);
                foreach (var query in queries)
                {
                    _queries.Add(new object[] { query });
                }
            }
            return _queries;
        }

        public static readonly IEnumerable<DomainEvent> _allEvents = new List<DomainEvent> {
            new TestEventA() { TimeStamp = new DateTime(2022, 8, 1) },
            new TestEventA() { TimeStamp = new DateTime(2022, 8, 15), PropertyA = "test" },
            new TestEventA() { TimeStamp = new DateTime(2022, 8, 30), PropertyA = "testovi" },
            new TestEventA() { TimeStamp = new DateTime(2022, 8, 15), PropertyA = "lalalalal" },
            new TestEventB() { TimeStamp = new DateTime(2022, 8, 1) },
            new TestEventB() { TimeStamp = new DateTime(2022, 8, 15), PropertyB = 1 },
            new TestEventB() { TimeStamp = new DateTime(2022, 8, 30), PropertyB = 15 },
            new TestEventB() { TimeStamp = new DateTime(2022, 8, 15), PropertyB = 30 },
            new TestEventC() { TimeStamp = new DateTime(2022, 8, 1) },
            new TestEventC() { TimeStamp = new DateTime(2022, 8, 15), PropertyB = 1 },
            new TestEventC() { TimeStamp = new DateTime(2022, 8, 30), PropertyB = 15 },
            new TestEventC() { TimeStamp = new DateTime(2022, 8, 15), PropertyB = 30 },
            new TestEventC() { TimeStamp = new DateTime(2022, 8, 30), PropertyB = 15, PropertyA = "test" },
            new TestEventC() { TimeStamp = new DateTime(2022, 8, 30), PropertyB = 30, PropertyA = "lala" },
        };

        private static readonly IEnumerable<DateTime> _afterParameters = new List<DateTime>
        {
            new DateTime(2022, 8, 15),
            new DateTime(2022, 8, 21),
            DateTime.MinValue
        };

        private static readonly IEnumerable<DateTime> _beforeParameters = new List<DateTime>
        {
            new DateTime(2022, 8, 15),
            new DateTime(2022, 8, 21),
            DateTime.MaxValue
        };

        private static readonly IEnumerable<ConditionParameter> _conditionParameters = new List<ConditionParameter>
        {
            new ConditionParameter(jsonEvent => jsonEvent.RootElement.GetProperty("PropertyA").GetString().Contains("test"),
                                   @event => @event.PropertyA.Contains("test")),
            new ConditionParameter(jsonEvent => jsonEvent.RootElement.GetProperty("PropertyB").GetInt32() >= 13,
                                    @event => @event.PropertyB >= 13),
            new ConditionParameter(jsonEvent => jsonEvent.RootElement.GetProperty("DoesntExist").GetInt32() >= 13,
                                    @event => @event.DoesntExist >= 13),
            new ConditionParameter(jsonEvent => jsonEvent.RootElement.GetProperty("PropertyB").GetInt32() >= 13 && jsonEvent.RootElement.GetProperty("PropertyA").GetString().Contains("test"),
                                    @event => @event.PropertyB >= 13 && @event.PropertyA.Contains("test"))
        };
    }
}
