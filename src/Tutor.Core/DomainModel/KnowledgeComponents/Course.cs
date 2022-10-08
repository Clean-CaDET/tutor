using System.Collections.Generic;

namespace Tutor.Core.DomainModel.KnowledgeComponents;

public class Course
{
    public int Id { get; private set; }
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public List<KnowledgeUnit> KnowledgeUnits { get; private set; }
}