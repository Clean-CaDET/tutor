using System.Text.Json.Serialization;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain.Report;

public class FeedbackItemAggregate : ValueObject
{
    public string Code { get; }
    public int[] Weeks { get; }
    public bool HasData { get; }
    public double Average { get; }
    public int[] ValueCounts { get; }

    [JsonConstructor]
    public FeedbackItemAggregate(string code, int[] weeks, bool hasData, double average, int[] valueCounts)
    {
        Code = code;
        Weeks = weeks;
        HasData = hasData;
        Average = average;
        ValueCounts = valueCounts;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        foreach (var week in Weeks)
        {
            yield return week;
        }
        yield return HasData;
        yield return Average;
        foreach (var count in ValueCounts)
        {
            yield return count;
        }
    }
}