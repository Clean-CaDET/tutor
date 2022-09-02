using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Infrastructure.Tests.TestData.EventStore;
using Tutor.Infrastructure.Tests.TestData.EventStore.EventQueryable;
using Xunit;
using static Tutor.Infrastructure.Tests.TestData.EventStore.EventQueryable.EventQueryableTestCase;
using static Tutor.Infrastructure.Tests.TestData.EventStore.TestEvents;

namespace Tutor.Infrastructure.Tests.Integration.EventStore
{
    public class EventQueryableTests : IClassFixture<EventStoreManager>
    {
        private readonly IEventQueryable _queryable;

        public EventQueryableTests(EventStoreManager eventStoreManager)
        {
            _queryable = eventStoreManager.EventStore.Events;
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Correctly_executes_query(EventQueryableTestCase testCase)
        {
            var expectedResult = testCase.GetExpectedResult(TestEvents.Examples);

            var result = testCase.Execute(_queryable).ToList();

            result.ShouldBe(expectedResult, true);
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Correctly_executes_query_with_type_cast(EventQueryableTestCase query)
        {
            var expectedResult = query.GetExpectedResult(TestEvents.Examples).OfType<TestEventB>();

            var result = query.Execute(_queryable).ToList<TestEventB>();

            result.ShouldBe(expectedResult, true);
        }

        public static IEnumerable<object[]> TestCases()
        {
            if (_testCases.Any()) return _testCases;
            _testCases = EventQueryableTestCaseGenerator.GenerateTestCases(_queryParameters, 65)
                .Select(testCase => new object[] { testCase });
            return _testCases;
        }

        private static IEnumerable<object[]> _testCases = new List<object[]>();

        private static IEnumerable<IQueryParameter> _queryParameters = new List<IQueryParameter>
        {
            new ConditionParameter(jsonEvent => jsonEvent.RootElement.GetProperty("PropertyA").GetString().Contains("test"),
                                   @event => @event.PropertyA.Contains("test")),
            new ConditionParameter(jsonEvent => jsonEvent.RootElement.GetProperty("PropertyB").GetInt32() >= 13,
                                    @event => @event.PropertyB >= 13),
            new ConditionParameter(jsonEvent => jsonEvent.RootElement.GetProperty("DoesntExist").GetInt32() >= 13,
                                    @event => @event.DoesntExist >= 13),
            new ConditionParameter(jsonEvent => jsonEvent.RootElement.GetProperty("PropertyB").GetInt32() >= 13 && jsonEvent.RootElement.GetProperty("PropertyA").GetString().Contains("test"),
                                    @event => @event.PropertyB >= 13 && @event.PropertyA.Contains("test")),
            new AfterParameter(DateTime.MinValue),
            new BeforeParameter(DateTime.MaxValue),
            new AfterParameter(new DateTime(2022, 7, 31)),
            new BeforeParameter(new DateTime(2022, 9, 1)),
            new AfterParameter(new DateTime(2022, 8, 1)),
            new BeforeParameter(new DateTime(2022, 8, 21)),
            new AfterParameter(new DateTime(2022, 8, 12)),
            new BeforeParameter(new DateTime(2022, 8, 15)),
            new AfterParameter(new DateTime(2022, 8, 21)),
            new BeforeParameter(new DateTime(2022, 8, 1)),
            new AfterParameter(new DateTime(2022, 9, 1)),
            new BeforeParameter(new DateTime(2022, 7, 31)),
            new AfterParameter(DateTime.MaxValue),
            new BeforeParameter(DateTime.MinValue),
        };
    }
}
