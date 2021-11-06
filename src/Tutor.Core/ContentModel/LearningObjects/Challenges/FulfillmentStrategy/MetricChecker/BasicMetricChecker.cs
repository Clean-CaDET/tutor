using System;
using System.Collections.Generic;
using System.Linq;
using CodeModel.CaDETModel.CodeItems;

namespace Tutor.Core.ContentModel.LearningObjects.Challenges.FulfillmentStrategy.MetricChecker
{
    public class BasicMetricChecker : ChallengeFulfillmentStrategy
    {
        public List<MetricRangeRule> ClassMetricRules { get; private set; }
        public List<MetricRangeRule> MethodMetricRules { get; private set; }

        private BasicMetricChecker() {}
        public BasicMetricChecker(List<MetricRangeRule> classMetricRules, List<MetricRangeRule> methodMetricRules, string codeSnippetId) : this()
        {
            ClassMetricRules = classMetricRules;
            MethodMetricRules = methodMetricRules;
            CodeSnippedId = codeSnippetId;
        }

        public override HintDirectory EvaluateSubmission(List<CaDETClass> solutionAttempt)
        {
            var challengeHints = GetApplicableHints(solutionAttempt);
            return challengeHints;
        }

        public override List<ChallengeHint> GetAllHints()
        {
            var challengeHints = new List<ChallengeHint>();
            challengeHints.AddRange(ClassMetricRules.Select(c => c.Hint));
            challengeHints.AddRange(MethodMetricRules.Select(m => m.Hint));
            return challengeHints;
        }

        private HintDirectory GetApplicableHints(List<CaDETClass> solutionAttempt)
        {
            var caDETClass = solutionAttempt.Find(c => c.FullName == CodeSnippedId);
            if (caDETClass != null)
                return GetApplicableHintsForIncompleteClass(caDETClass);
            
            var caDETMember = GetMethodsFromClasses(solutionAttempt).FirstOrDefault(m => m.Signature() == CodeSnippedId);
            if (caDETMember != null)
                return GetApplicableHintsForIncompleteMethod(caDETMember);

            // foreach (var name in PossibleRenames)
            // {
            //     caDETClass = solutionAttempt.Find(c => c.FullName == name);
            //     if (caDETClass != null)
            //         return GetApplicableHintsForIncompleteClasses(caDETClass);
            //     caDETMember = solutionAttempt.SelectMany(c => c.Members).FirstOrDefault(m => m.Signature() == name);
            //     if (caDETMember != null)
            //         return GetApplicableHintsForIncompleteMethods(caDETMember);
            // }

            throw new Exception($"Solution attempt is missing class/method {CodeSnippedId}");
        }

        private HintDirectory GetApplicableHintsForIncompleteClass(CaDETClass caDETClass)
        {
            var challengeHints = new HintDirectory();
            foreach (var metricRule in ClassMetricRules)
            {
                var result = metricRule.Evaluate(caDETClass.Metrics);
                if (result == null) continue;
                challengeHints.AddHint(caDETClass.FullName, result);
            }
            return challengeHints;
        }

        private HintDirectory GetApplicableHintsForIncompleteMethod(CaDETMember caDETMethod)
        {
            var challengeHints = new HintDirectory();
            foreach (var metricRule in MethodMetricRules)
            {
                var result = metricRule.Evaluate(caDETMethod.Metrics);
                if (result == null) continue;
                challengeHints.AddHint(caDETMethod.Signature(), result);
            }
            return challengeHints;
        }

        private List<CaDETMember> GetMethodsFromClasses(List<CaDETClass> classes)
        {
            return classes.SelectMany(c => c.Members.Where(m => m.Type.Equals(CaDETMemberType.Method))).ToList();
        }
    }
}