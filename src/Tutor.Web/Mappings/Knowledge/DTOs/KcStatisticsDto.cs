using System.Collections.Generic;
using System.Linq;

namespace Tutor.Web.Mappings.Knowledge.DTOs;

public class KcStatisticsDto
{
    public int KcId { get; set; }
    public int TotalRegistered { get; set; }
    public int TotalStarted { get; set; }
    public int TotalCompleted { get; set; }
    public int TotalPassed { get; set; }
    public List<double> MinutesToCompletion { get; set; }
    public List<double> MinutesToPass { get; set; }

    public override int GetHashCode()
    {
        return KcId.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is not KcStatisticsDto other) return false;
        return KcId == other.KcId
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