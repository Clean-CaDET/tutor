using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.Domain.Knowledge.KnowledgeComponents
{
    public class KcStatistics
    {
        public string KcCode { get; init; }
        public string KcName { get; init; }
        public int TotalRegistered { get; init; }
        public int TotalStarted { get; init; }
        public int TotalCompleted { get; init; }
        public int TotalPassed { get; init; }
        public List<int> MinutesToCompletion { get; init; }
        public List<int> MinutesToPass { get; init; }

        public override int GetHashCode()
        {
            return KcCode.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is not KcStatistics other) return false;
            return KcCode == other.KcCode
                   && TotalCompleted == other.TotalCompleted
                   && TotalPassed == other.TotalPassed
                   && TotalStarted == other.TotalStarted
                   && TotalRegistered == other.TotalRegistered
                   && MinutesToCompletion.Count == other.MinutesToCompletion.Count
                   && MinutesToPass.Count == other.MinutesToPass.Count
                   && MinutesToCompletion.All(other.MinutesToCompletion.Contains)
                   && MinutesToPass.All(other.MinutesToPass.Contains);
        }
    }
}
