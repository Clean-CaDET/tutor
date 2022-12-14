using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.Structure;

public class Course : Entity
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsArchived { get; set; }
    public List<KnowledgeUnit> KnowledgeUnits { get; private set; }
}