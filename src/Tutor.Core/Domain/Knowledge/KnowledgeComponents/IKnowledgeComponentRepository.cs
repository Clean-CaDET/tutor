using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.KnowledgeComponents
{
    public interface IKnowledgeComponentRepository
    {
        List<KnowledgeComponent> GetKnowledgeComponentsForUnit(int unitId);
    }
}
