using System;
using System.Collections.Generic;
using System.Linq;
using static Tutor.Infrastructure.Tests.TestData.EventStore.EventQueryableTestCase;

namespace Tutor.Infrastructure.Tests.TestData.EventStore.EventQueryable
{
    public static class EventQueryableTestCaseGenerator
    {
        private static IEnumerable<object[]> _testCases = new List<object[]>();

        public static IEnumerable<object[]> GenerateTestCases(IEnumerable<QueryParameter> parameters, int amountPerParameter)
        {
            if (!_testCases.Any())
            {
                var testCases = new List<EventQueryableTestCase> { new EventQueryableTestCase() };
                foreach (var parameter in parameters)
                    testCases.AddRange(GenerateTestCasesWithParameter(testCases, parameter, amountPerParameter));
                _testCases = testCases.Select(query => new object[] { query });
            }
            return _testCases;
        }

        private static List<EventQueryableTestCase> GenerateTestCasesWithParameter(
            List<EventQueryableTestCase> currentTestCases, QueryParameter parameter, int amount)
        {
            var testCasesWithParameter = new List<EventQueryableTestCase>();
            foreach (var index in GenerateRandomIndexes(amount, currentTestCases.Count))
            {
                var query = currentTestCases[index];
                testCasesWithParameter.Add(new EventQueryableTestCase()
                {
                    QueryParameters = query.QueryParameters.Append(parameter),
                });
            }
            return testCasesWithParameter;
        }

        private static IEnumerable<int> GenerateRandomIndexes(int amount, int listCount)
        {
            var indexes = new HashSet<int>();

            if (listCount <= amount)
            {
                for (int i = 0; i < listCount; i++) indexes.Add(i);
            }
            else
            {
                var random = new Random(Guid.NewGuid().GetHashCode());
                while (indexes.Count < amount)
                {
                    int possibleIndex = random.Next(0, listCount);
                    if (!indexes.Contains(possibleIndex))
                        indexes.Add(possibleIndex);
                }
            }

            return indexes;
        }
    }
}
