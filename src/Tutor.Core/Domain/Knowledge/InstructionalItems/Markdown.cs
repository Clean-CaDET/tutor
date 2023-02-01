using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.InstructionalItems;

public class Markdown : InstructionalItem
{
    public string Content { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return KnowledgeComponentId;
        yield return Content;
    }
}