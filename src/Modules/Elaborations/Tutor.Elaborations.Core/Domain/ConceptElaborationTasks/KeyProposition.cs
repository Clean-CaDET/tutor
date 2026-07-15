using System.Text.Json.Serialization;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class KeyProposition : ValueObject
{
    [JsonPropertyName("key")]
    public string Key { get; }
    [JsonPropertyName("statement")]
    public string Statement { get; }
    [JsonPropertyName("hint")]
    public string? Hint { get; }
    [JsonPropertyName("misconception")]
    public Misconception? Misconception { get; }

    [JsonConstructor]
    public KeyProposition(string key, string statement, string? hint = null, Misconception? misconception = null)
    {
        Key = key;
        Statement = statement;
        Hint = hint;
        Misconception = misconception;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Key;
        yield return Statement;
        if (Hint != null) yield return Hint;
        if (Misconception != null) yield return Misconception;
    }
}
