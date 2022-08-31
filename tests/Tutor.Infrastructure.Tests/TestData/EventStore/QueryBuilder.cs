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
            IEnumerable<Query> queries = new List<Query> { new Query() };

            foreach (var afterParameter in afterParameters)
                queries = AddAfterParameter(queries, afterParameter);
            foreach (var beforeParameter in beforeParameters)
                queries = AddBeforeParameter(queries, beforeParameter);
            foreach (var conditionParameter in conditionParameters)
                queries = AddConditionParameter(queries, conditionParameter);

            return queries;
        }

        public static IEnumerable<Query> AddAfterParameter(IEnumerable<Query> currentQueries, DateTime afterParameter)
        {
            var newQueries = new List<Query>(currentQueries);

            foreach (var query in currentQueries)
            {
                newQueries.Add(new Query()
                {
                    AfterParameters = query.AfterParameters.Append(afterParameter),
                    BeforeParameters = query.BeforeParameters,
                    ConditionParameters = query.ConditionParameters
                });
            }

            return newQueries;
        }

        public static IEnumerable<Query> AddBeforeParameter(IEnumerable<Query> currentQueries, DateTime beforeParameter)
        {
            var newQueries = new List<Query>(currentQueries);

            foreach (var query in currentQueries)
            {
                newQueries.Add(new Query()
                {
                    AfterParameters = query.AfterParameters,
                    BeforeParameters = query.BeforeParameters.Append(beforeParameter),
                    ConditionParameters = query.ConditionParameters
                });
            }

            return newQueries;
        }

        public static IEnumerable<Query> AddConditionParameter(IEnumerable<Query> currentQueries, ConditionParameter conditionParameter)
        {
            var newQueries = new List<Query>(currentQueries);

            foreach (var query in currentQueries)
            {
                newQueries.Add(new Query()
                {
                    AfterParameters = query.AfterParameters,
                    BeforeParameters = query.BeforeParameters,
                    ConditionParameters = query.ConditionParameters.Append(conditionParameter)
                });
            }

            return newQueries;
        }
    }
}
