using System.Text.Json.Serialization;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class CommonMisconception : ValueObject
{
    [JsonPropertyName("key")]
    public string Key { get; }
    [JsonPropertyName("description")]
    public string Description { get; }
    [JsonPropertyName("correction")]
    public string Correction { get; }

    [JsonConstructor]
    public CommonMisconception(string key, string description, string correction)
    {
        Key = key;
        Description = description;
        Correction = correction;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Key;
        yield return Description;
        yield return Correction;
    }
}
