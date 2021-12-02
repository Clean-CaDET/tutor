using CodeModel.CaDETModel.CodeItems;
using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker
{
    public class BasicMetricChecker : ChallengeFulfillmentStrategy
    {
        public List<MetricRangeRule> MetricRanges { get; private set; }

        private BasicMetricChecker() {}
        public BasicMetricChecker(List<MetricRangeRule> metricRanges, string codeSnippetId) : base(0, codeSnippetId)
        {
            MetricRanges = metricRanges;
        }

        protected override HintDirectory EvaluateClass(CaDETClass solutionAttempt)
        {
            var hints = new HintDirectory();
            hints.MergeHints(CheckMetricRanges(solutionAttempt.Metrics, solutionAttempt.FullName));
            solutionAttempt.Members.ForEach(m => hints.MergeHints(EvaluateMember(m)));
            return hints;
        }

        protected override HintDirectory EvaluateMember(CaDETMember solutionAttempt)
        {
            return CheckMetricRanges(solutionAttempt.Metrics, solutionAttempt.Signature());
        }

        private HintDirectory CheckMetricRanges(Dictionary<CaDETMetric, double> metrics, string codeSnippetId)
        {
            var challengeHints = new HintDirectory();
            foreach (var metricRule in MetricRanges)
            {
                var result = metricRule.Evaluate(metrics);
                if (result == null) continue;
                challengeHints.AddHint(codeSnippetId, result);
            }
            return challengeHints;
        }
    }
}