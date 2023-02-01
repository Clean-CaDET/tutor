using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems;

public class HintDto : ValueObject
{
    public string Markdown { get; set; }
    public int Order { get; set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Markdown;
        yield return Order;
    }
}