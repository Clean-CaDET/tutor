using System.Text.Json.Serialization;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class WeeklyFeedbackItem : ValueObject
{
    [JsonPropertyName("code")] // Needed because of legacy data with lowercase property names
    public string Code { get; }
    [JsonPropertyName("value")]
    public int Value { get; }
    [JsonPropertyName("label")]
    public string Label { get; }

    [JsonConstructor]
    public WeeklyFeedbackItem(string code, string label, int value)
    {
        Code = code;
        Value = value;
        Label = label;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Value;
        yield return Label;
    }
}