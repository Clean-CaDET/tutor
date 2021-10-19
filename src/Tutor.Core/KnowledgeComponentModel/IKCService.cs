using System.Collections.Generic;
using Tutor.Core.KnowledgeComponentModel.KnowledgeComponents;

namespace Tutor.Core.KnowledgeComponentModel
{
    public interface IKCService
    {
        public List<KnowledgeComponent> GetKnowledgeComponents();
    }
}