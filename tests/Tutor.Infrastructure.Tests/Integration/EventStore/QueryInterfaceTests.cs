using Shouldly;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Infrastructure.Tests.TestData.EventStore;
using Xunit;

namespace Tutor.Infrastructure.Tests.Integration.EventStore
{
    public class QueryInterfaceTests : IClassFixture<EventStoreManager>
    {
        private readonly IEventStore _eventStore;

        public QueryInterfaceTests(EventStoreManager eventStoreManager)
        {
            _eventStore = eventStoreManager.EventStore;
        }

        [Theory]
        [MemberData(nameof(QueryTestData.GetQueries), MemberType = typeof(QueryTestData))]
        public void After_before_conditions(Query parameters)
        {
            var _expectedResult = parameters.GetExpectedResult(TestEvents.Examples);

            var query = _eventStore.Events;
            foreach (var moment in parameters.AfterParameters) query = query.After(moment);
            foreach (var moment in parameters.BeforeParameters) query = query.Before(moment);
            foreach (var condition in parameters.ConditionParameters) query = query.Where(condition.JsonCondition);
            var result = query.ToList();

            result.ShouldBe(_expectedResult, true);
        }

        [Theory]
        [MemberData(nameof(QueryTestData.GetQueries), MemberType = typeof(QueryTestData))]
        public void After_conditions_before(Query parameters)
        {
            var _expectedResult = parameters.GetExpectedResult(TestEvents.Examples);

            var query = _eventStore.Events;
            foreach (var moment in parameters.AfterParameters) query = query.After(moment);
            foreach (var condition in parameters.ConditionParameters) query = query.Where(condition.JsonCondition);
            foreach (var moment in parameters.BeforeParameters) query = query.Before(moment);
            var result = query.ToList();

            result.ShouldBe(_expectedResult, true);
        }

        [Theory]
        [MemberData(nameof(QueryTestData.GetQueries), MemberType = typeof(QueryTestData))]
        public void Before_after_conditions(Query parameters)
        {
            var _expectedResult = parameters.GetExpectedResult(TestEvents.Examples);

            var query = _eventStore.Events;
            foreach (var moment in parameters.BeforeParameters) query = query.Before(moment);
            foreach (var moment in parameters.AfterParameters) query = query.After(moment);
            foreach (var condition in parameters.ConditionParameters) query = query.Where(condition.JsonCondition);
            var result = query.ToList();

            result.ShouldBe(_expectedResult, true);
        }

        [Theory]
        [MemberData(nameof(QueryTestData.GetQueries), MemberType = typeof(QueryTestData))]
        public void Before_conditions_after(Query parameters)
        {
            var _expectedResult = parameters.GetExpectedResult(TestEvents.Examples);

            var query = _eventStore.Events;
            foreach (var moment in parameters.BeforeParameters) query = query.Before(moment);
            foreach (var condition in parameters.ConditionParameters) query = query.Where(condition.JsonCondition);
            foreach (var moment in parameters.AfterParameters) query = query.After(moment);
            var result = query.ToList();

            result.ShouldBe(_expectedResult, true);
        }

        [Theory]
        [MemberData(nameof(QueryTestData.GetQueries), MemberType = typeof(QueryTestData))]
        public void Conditions_after_before(Query parameters)
        {
            var _expectedResult = parameters.GetExpectedResult(TestEvents.Examples);

            var query = _eventStore.Events;
            foreach (var condition in parameters.ConditionParameters) query = query.Where(condition.JsonCondition);
            foreach (var moment in parameters.AfterParameters) query = query.After(moment);
            foreach (var moment in parameters.BeforeParameters) query = query.Before(moment);
            var result = query.ToList();

            result.ShouldBe(_expectedResult, true);
        }

        [Theory]
        [MemberData(nameof(QueryTestData.GetQueries), MemberType = typeof(QueryTestData))]
        public void Conditions_before_after(Query parameters)
        {
            var _expectedResult = parameters.GetExpectedResult(TestEvents.Examples);

            var query = _eventStore.Events;
            foreach (var condition in parameters.ConditionParameters) query = query.Where(condition.JsonCondition);
            foreach (var moment in parameters.BeforeParameters) query = query.Before(moment);
            foreach (var moment in parameters.AfterParameters) query = query.After(moment);
            var result = query.ToList();

            result.ShouldBe(_expectedResult, true);
        }
    }
}
