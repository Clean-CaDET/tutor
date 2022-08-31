using System;
using System.Collections.Generic;
using System.Linq;
using static Tutor.Infrastructure.Tests.TestData.EventStore.Query;

namespace Tutor.Infrastructure.Tests.TestData.EventStore
{
    public static class QueryBuilder
    {
        public static IEnumerable<Query> BuildAllPossibleQueries(IEnumerable<DateTime> afterParameters,
                                                                 IEnumerable<DateTime> beforeParameters,
                                                                 IEnumerable<ConditionParameter> conditionParameters)
        {
            IList<Query> queries = new List<Query> { new Query() };

            foreach (var conditionParameter in conditionParameters)
                queries = AddConditionParameter(queries, conditionParameter);
            foreach (var afterParameter in afterParameters)
                queries = AddAfterParameter(queries, afterParameter);
            foreach (var beforeParameter in beforeParameters)
                queries = AddBeforeParameter(queries, beforeParameter);

            return queries;
        }

        public static IList<Query> AddAfterParameter(IList<Query> currentQueries, DateTime afterParameter)
        {
            var newQueries = new List<Query>(currentQueries);

            var indexes = GenerateIndexes(20, newQueries.Count);
            foreach (var index in indexes)
            {
                var query = currentQueries.ElementAt(index);
                newQueries.Add(new Query()
                {
                    AfterParameters = query.AfterParameters.Append(afterParameter),
                    BeforeParameters = query.BeforeParameters,
                    ConditionParameters = query.ConditionParameters
                });
            }

            return newQueries;
        }

        public static IList<Query> AddBeforeParameter(IList<Query> currentQueries, DateTime beforeParameter)
        {
            var newQueries = new List<Query>(currentQueries);

            var indexes = GenerateIndexes(20, newQueries.Count);
            foreach (var index in indexes)
            {
                var query = currentQueries.ElementAt(index);
                newQueries.Add(new Query()
                {
                    AfterParameters = query.AfterParameters,
                    BeforeParameters = query.BeforeParameters.Append(beforeParameter),
                    ConditionParameters = query.ConditionParameters
                });
            }

            return newQueries;
        }

        public static IList<Query> AddConditionParameter(IList<Query> currentQueries, ConditionParameter conditionParameter)
        {
            var newQueries = new List<Query>(currentQueries);

            var indexes = GenerateIndexes(20, newQueries.Count);
            foreach (var index in indexes)
            {
                var query = currentQueries.ElementAt(index);
                newQueries.Add(new Query()
                {
                    AfterParameters = query.AfterParameters,
                    BeforeParameters = query.BeforeParameters,
                    ConditionParameters = query.ConditionParameters.Append(conditionParameter)
                });
            }

            return newQueries;
        }

        private static IEnumerable<int> GenerateIndexes(int maxAmount, int listCount)
        {
            var indexes = new HashSet<int>();

            if (listCount <= maxAmount)
            {
                for (int i = 0; i < listCount; i++) indexes.Add(i);
            }
            else
            {
                var random = new Random(Guid.NewGuid().GetHashCode());
                while (indexes.Count < maxAmount)
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
