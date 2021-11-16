using System.Collections.Generic;

namespace Tutor.Core.DomainModel.Units
{
    public class UnitKnowledgeComponent
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<KnowledgeNode> KnowledgeNodes { get; private set; }
    }
}