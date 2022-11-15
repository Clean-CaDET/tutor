using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.KnowledgeComponents
{
    public interface IKnowledgeRepository
    {
        KnowledgeUnit GetUnitWithKcs(int unitId);
        List<KnowledgeComponent> GetKnowledgeComponentsForUnit(int unitId);
    }
}
