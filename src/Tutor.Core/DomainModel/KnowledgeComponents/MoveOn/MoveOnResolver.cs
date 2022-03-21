using System;
using System.Collections.Generic;

namespace Tutor.Core.DomainModel.KnowledgeComponents.MoveOn
{
    public static class MoveOnResolver
    {
        private static readonly IDictionary<string, Type> possibleCriterias = new Dictionary<string, Type>()
        {
            { "Passed", typeof(Passed) },
            { "Completed", typeof(Completed) },
            { "CompletedAndPassed", typeof(CompletedAndPassed) },
            { "CompletedOrPassed", typeof(CompletedOrPassed) },
            { "NotApplicable", typeof(NotApplicable) }
        };

        public static Type ResolveOrDefault(string moveOnCriteria)
        {
            if (moveOnCriteria == null)
                return Default();
            Type type;
            possibleCriterias.TryGetValue(moveOnCriteria, out type);
            return type ?? Default();
        }

        public static Type Default() => typeof(Passed);
    }
}
