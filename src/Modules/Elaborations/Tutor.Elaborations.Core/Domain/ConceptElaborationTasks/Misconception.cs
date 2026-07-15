using System.Text.Json.Serialization;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class Misconception : ValueObject
{
    [JsonPropertyName("description")]
    public string Description { get; }
    [JsonPropertyName("correction")]
    public string Correction { get; }

    [JsonConstructor]
    public Misconception(string description, string correction)
    {
        Description = description;
        Correction = correction;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Description;
        yield return Correction;
    }
}
