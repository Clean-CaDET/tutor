using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems;

public class Hint: ValueObject
{
    public string Markdown { get; private set; }
    public int Order { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Markdown;
        yield return Order;
    }
}