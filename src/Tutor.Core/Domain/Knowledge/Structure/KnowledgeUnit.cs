using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.Structure;

public class KnowledgeUnit : Entity
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Course Course { get; private set; }
    public List<KnowledgeComponent> KnowledgeComponents { get; private set; }
}