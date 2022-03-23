using System;
using CodeModel.CaDETModel.CodeItems;
using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker
{
    public class BasicMetricChecker : ChallengeFulfillmentStrategy
    {
        public string MetricName { get; private set; }
        public double FromValue { get; private set; }
        public double ToValue { get; private set; }
        public ChallengeHint Hint { get; private set; }

        private BasicMetricChecker() {}
        public BasicMetricChecker(int id, string metricName, int fromValue, int toValue, ChallengeHint challengeHint, string codeSnippetId) : base(id, codeSnippetId)
        {
            MetricName = metricName;
            FromValue = fromValue;
            ToValue = toValue;
            Hint = challengeHint;
        }

        private HintDirectory EvaluateClass(CaDETClass solutionAttempt)
        {
            var hints = new HintDirectory();
            hints.MergeHints(CheckMetricRanges(solutionAttempt.Metrics, solutionAttempt.FullName));
            return hints;
        }

        protected override HintDirectory EvaluateMember(CaDETMember solutionAttempt)
        {
            return CheckMetricRanges(solutionAttempt.Metrics, solutionAttempt.Signature());
        }

        private HintDirectory CheckMetricRanges(Dictionary<CaDETMetric, double> metrics, string codeSnippetId)
        {
            var challengeHints = new HintDirectory();

            var result = Evaluate(metrics);
            if (result != null) challengeHints.AddHint(codeSnippetId, result);
            return challengeHints;
        }

        private ChallengeHint Evaluate(Dictionary<CaDETMetric, double> metrics)
        {
            var metric = (CaDETMetric)Enum.Parse(typeof(CaDETMetric), MetricName, true);
            if (!metrics.ContainsKey(metric)) return null;

            var metricValue = metrics[metric];
            var isFulfilled = FromValue <= metricValue && metricValue <= ToValue;
            return isFulfilled ? null : Hint;
        }

        protected override HintDirectory EvaluateClassesAndMembers(List<CaDETClass> solutionAttempt)
        {
            var hints = new HintDirectory();
            foreach (var c in solutionAttempt)
            {
                hints.MergeHints(EvaluateClass(c));
                c.Members.ForEach(m => hints.MergeHints(EvaluateMember(m)));
            }

            return hints;
        }
    }
}