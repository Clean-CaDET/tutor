using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;

public abstract class InstructionalItem : Entity
{
    public int KnowledgeComponentId { get; private set; }
    public int Order { get; protected set; }

    public abstract InstructionalItem Clone();
}