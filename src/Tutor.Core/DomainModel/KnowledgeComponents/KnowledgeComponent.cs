using System.Collections.Generic;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KnowledgeComponent
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public List<KnowledgeComponent> KnowledgeComponents { get; private set; }
    }
}