using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.Structure;

public class KcStatistics : ValueObject
{
    public string KcCode { get; init; }
    public string KcName { get; init; }
    public int TotalRegistered { get; init; }
    public int TotalStarted { get; init; }
    public int TotalCompleted { get; init; }
    public int TotalPassed { get; init; }
    public List<int> MinutesToCompletion { get; init; }
    public List<int> MinutesToPass { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return KcCode;
        yield return TotalCompleted;
        yield return TotalPassed;
        yield return TotalStarted;
        yield return TotalRegistered;
        foreach (var minutes in MinutesToCompletion)
        {
            yield return minutes;
        }
        foreach (var minutes in MinutesToPass)
        {
            yield return minutes;
        }
    }
}