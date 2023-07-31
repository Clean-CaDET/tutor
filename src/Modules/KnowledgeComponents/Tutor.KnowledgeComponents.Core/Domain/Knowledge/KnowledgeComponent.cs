using Tutor.BuildingBlocks.Core.Domain;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge;

public class KnowledgeComponent : Entity
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public int Order { get; private set; }
    public int? ExpectedDurationInMinutes { get; private set; }
    public int KnowledgeUnitId { get; private set; }
    public int? ParentId { get; internal set; }
    public List<AssessmentItem>? AssessmentItems { get; private set; }
    public List<InstructionalItem>? InstructionalItems { get; private set; }

    internal KnowledgeComponent Clone(int unitId)
    {
        return new KnowledgeComponent
        {
            Code = Code,
            Name = Name,
            Description = Description,
            Order = Order,
            ExpectedDurationInMinutes = ExpectedDurationInMinutes,
            KnowledgeUnitId = unitId,
            ParentId = ParentId,
            InstructionalItems = InstructionalItems?.Select(i => i.Clone()).ToList(),
            AssessmentItems = AssessmentItems?.Select(a => a.Clone()).ToList()
        };
    }
}