using System.Text.Json.Serialization;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptRecords;

public class BoundaryCondition : ValueObject
{
    [JsonPropertyName("key")]
    public string Key { get; }
    [JsonPropertyName("statement")]
    public string Statement { get; }

    [JsonConstructor]
    public BoundaryCondition(string key, string statement)
    {
        Key = key;
        Statement = statement;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Key;
        yield return Statement;
    }
}
