using System.Collections.Generic;
using Tutor.Core.KnowledgeComponentModel.KnowledgeComponents;

namespace Tutor.Core.KnowledgeComponentModel
{
    public interface IKCRepository
    {
        List<KnowledgeComponent> GetKnowledgeComponent();
    }
}