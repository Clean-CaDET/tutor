using System;
using System.Collections.Generic;
using System.Linq;
using CodeModel.CaDETModel;
using CodeModel.CaDETModel.CodeItems;

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

        public override HintDirectory EvaluateSubmission(CaDETProject solutionAttempt)
        {
            var cadetClass = solutionAttempt.Classes.Find(c => c.FullName == CodeSnippetId);
            if (cadetClass != null) return CheckClassMetricRanges(cadetClass);

            var memberMetrics = solutionAttempt.GetMetricsForCodeSnippet(CodeSnippetId);
            if (memberMetrics != null) return CheckMetricRanges(memberMetrics);

            throw new InvalidOperationException($"Solution attempt is missing class/method {CodeSnippetId}");
        }

        private HintDirectory CheckClassMetricRanges(CaDETClass cadetClass)
        {
            var challengeHints = new HintDirectory();
            challengeHints.MergeHints(CheckMetricRanges(cadetClass.Metrics));
            cadetClass.Members.ForEach(m => challengeHints.MergeHints(CheckMetricRanges(m.Metrics)));
            return challengeHints;
        }

        private HintDirectory CheckMetricRanges(Dictionary<CaDETMetric, double> metrics)
        {
            var challengeHints = new HintDirectory();
            foreach (var metricRule in MetricRanges)
            {
                var result = metricRule.Evaluate(metrics);
                if (result == null) continue;
                challengeHints.AddHint(CodeSnippetId, result);
            }
            return challengeHints;
        }

        public override List<ChallengeHint> GetAllHints()
        {
            return MetricRanges.Select(c => c.Hint).ToList();
        }
    }
}