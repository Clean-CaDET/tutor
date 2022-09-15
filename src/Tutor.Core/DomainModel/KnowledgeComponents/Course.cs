using System.Collections.Generic;

namespace Tutor.Core.DomainModel.KnowledgeComponents;

public class Course
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<KnowledgeUnit> KnowledgeUnits { get; private set; }
}