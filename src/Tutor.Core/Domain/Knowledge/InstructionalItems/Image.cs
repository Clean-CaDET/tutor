using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.InstructionalItems;

public class Image : InstructionalItem
{
    public string Url { get; private set; }
    public string Caption { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return KnowledgeComponentId;
        yield return Url;
        yield return Caption;
    }
}