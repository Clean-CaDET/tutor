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
        public BasicMetricChecker(List<MetricRangeRule> metricRanges, string codeSnippetId, List<string> possibleRenames) : base(0, codeSnippetId, possibleRenames)
        {
            MetricRanges = metricRanges;
        }

        public override HintDirectory EvaluateSubmission(CaDETProject solutionAttempt)
        {
            var metrics = solutionAttempt.GetMetricsForCodeSnippet(CodeSnippetId);
            if (metrics != null) return CheckMetricRangeRules(metrics);

            if (PossibleRenames == null)
                throw new Exception($"Solution attempt is missing class/method {CodeSnippetId}");

            foreach (var rename in PossibleRenames)
            {
                metrics = solutionAttempt.GetMetricsForCodeSnippet(rename);
                if (metrics != null)
                {
                    return CheckMetricRangeRules(metrics);
                }
            }

            throw new Exception($"Solution attempt is missing class/method {CodeSnippetId}");
        }

        public override List<ChallengeHint> GetAllHints()
        {
            var challengeHints = new List<ChallengeHint>();
            challengeHints.AddRange(MetricRanges.Select(c => c.Hint));
            return challengeHints;
        }

        private HintDirectory CheckMetricRangeRules(Dictionary<CaDETMetric, double> metrics)
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
    }
}