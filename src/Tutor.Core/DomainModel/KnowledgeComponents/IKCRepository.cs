using System.Collections.Generic;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKCRepository
    {
        List<KnowledgeComponent> GetKnowledgeComponent();
    }
}