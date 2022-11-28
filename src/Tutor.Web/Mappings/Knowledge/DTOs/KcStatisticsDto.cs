using System.Collections.Generic;
using System.Linq;

namespace Tutor.Web.Mappings.Knowledge.DTOs;

public class KcStatisticsDto
{
    public string KcCode { get; set; }
    public string KcName { get; set; }
    public int TotalRegistered { get; set; }
    public int TotalStarted { get; set; }
    public int TotalCompleted { get; set; }
    public int TotalPassed { get; set; }
    public List<int> MinutesToCompletion { get; set; }
    public List<int> MinutesToPass { get; set; }

    public override int GetHashCode()
    {
        return KcCode.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is not KcStatisticsDto other) return false;
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