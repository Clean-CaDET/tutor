using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.EventSourcing;
using static Tutor.Infrastructure.Tests.TestData.EventStore.Query;
using static Tutor.Infrastructure.Tests.TestData.EventStore.TestEvents;

namespace Tutor.Infrastructure.Tests.TestData.EventStore
{
    public static class QueryTestData
    {
        private static ICollection<object[]> _queries = new List<object[]>();

        public static IEnumerable<object[]> GetQueries()
        {
            if (_queries.Count == 0)
            {
                var queries = QueryBuilder.BuildAllPossibleQueries(_timeParameters, _timeParameters, _conditionParameters);
                foreach (var query in queries)
                {
                    _queries.Add(new object[] { query });
                }
            }
            return _queries;
        }

        private static readonly IEnumerable<DateTime> _timeParameters = new List<DateTime>
        {
            new DateTime(2022, 7, 31),
            new DateTime(2022, 8, 1),
            new DateTime(2022, 8, 12),
            new DateTime(2022, 8, 15),
            new DateTime(2022, 8, 21),
            new DateTime(2022, 9, 1),
            DateTime.MinValue,
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
