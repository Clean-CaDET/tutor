using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.InstructionalItems;

public abstract class InstructionalItem : ValueObject
{
    public int Id { get; private set; }
    public int KnowledgeComponentId { get; private set; }
    public int Order { get; private set; }
}