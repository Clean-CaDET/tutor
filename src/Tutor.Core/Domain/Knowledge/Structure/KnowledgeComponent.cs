using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.InstructionalItems;

namespace Tutor.Core.Domain.Knowledge.Structure;

public class KnowledgeComponent : Entity
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Order { get; private set; }
    public int? ExpectedDurationInMinutes { get; private set; }

    public int KnowledgeUnitId { get; private set; }
    public int? ParentId { get; private set; }
    public List<KnowledgeComponent> KnowledgeComponents { get; private set; }
    public List<AssessmentItem> AssessmentItems { get; private set; }
    public List<InstructionalItem> InstructionalItems { get; private set; }

    public List<InstructionalItem> GetOrderedInstructionalItems()
    {
        return InstructionalItems.OrderBy(i => i.Order).ToList();
    }
}