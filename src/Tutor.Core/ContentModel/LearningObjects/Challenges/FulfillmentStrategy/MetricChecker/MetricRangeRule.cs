using System;
using System.Collections.Generic;
using CodeModel.CaDETModel.CodeItems;

namespace Tutor.Core.ContentModel.LearningObjects.Challenges.FulfillmentStrategy.MetricChecker
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
            var metric = (CaDETMetric) Enum.Parse(typeof(CaDETMetric), MetricName, true);
            if (!metrics.ContainsKey(metric)) return null;

            var metricValue = metrics[metric];
            var isFulfilled = FromValue <= metricValue && metricValue <= ToValue;
            return isFulfilled ? null : Hint;
        }
    }
}
