using System.Text.Json.Serialization;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;

public class Hint: ValueObject
{
    public string Markdown { get; private set; }
    public int Order { get; private set; }

    [JsonConstructor]
    public Hint(string markdown, int order)
    {
        Markdown = markdown;
        Order = order;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Markdown;
        yield return Order;
    }
}