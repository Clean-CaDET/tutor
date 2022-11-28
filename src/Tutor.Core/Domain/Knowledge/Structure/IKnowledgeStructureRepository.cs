using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.Structure
{
    public interface IKnowledgeStructureRepository
    {
        KnowledgeUnit GetUnitWithKcs(int unitId);
        List<KnowledgeComponent> GetKnowledgeComponentsForUnit(int unitId);
        KnowledgeComponent GetKnowledgeComponentWithInstruction(int knowledgeComponentId);
    }
}
