using System.Collections.Generic;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKCService
    {
        public List<KnowledgeComponent> GetKnowledgeComponents();
    }
}