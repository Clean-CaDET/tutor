using System;
using System.Collections.Generic;
using CodeModel.CaDETModel.CodeItems;

namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker
{
    public class MetricRangeRule
    {
        public int Id { get; private set; }
        public string MetricName { get; private set; }
        public double FromValue { get; private set; }
        public double ToValue { get; private set; }
        public ChallengeHint Hint { get; private set; }

        private MetricRangeRule() {}
        public MetricRangeRule(int id, string metricName, int fromValue, int toValue, ChallengeHint hint): this()
        {
            Id = id;
            MetricName = metricName;
            FromValue = fromValue;
            ToValue = toValue;
            Hint = hint;
        }

        internal ChallengeHint Evaluate(Dictionary<CaDETMetric, double> metrics)
        {
            var metricValue = metrics[(CaDETMetric)Enum.Parse(typeof(CaDETMetric), MetricName, true)];
            var isFulfilled = FromValue <= metricValue && metricValue <= ToValue;
            return isFulfilled ? null : Hint;
        }
    }
}
