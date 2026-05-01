using System.Text.Json.Serialization;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class KeyRelation : ValueObject
{
    [JsonPropertyName("key")]
    public string Key { get; }
    [JsonPropertyName("sourceKey")]
    public string SourceKey { get; }
    [JsonPropertyName("targetKey")]
    public string TargetKey { get; }
    [JsonPropertyName("mechanism")]
    public string Mechanism { get; }

    [JsonConstructor]
    public KeyRelation(string key, string sourceKey, string targetKey, string mechanism)
    {
        Key = key;
        SourceKey = sourceKey;
        TargetKey = targetKey;
        Mechanism = mechanism;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Key;
        yield return SourceKey;
        yield return TargetKey;
        yield return Mechanism;
    }
}
