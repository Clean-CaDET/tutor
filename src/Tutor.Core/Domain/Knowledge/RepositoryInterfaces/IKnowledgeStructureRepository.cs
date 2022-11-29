using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Knowledge.RepositoryInterfaces;

public interface IKnowledgeStructureRepository
{
    KnowledgeUnit GetUnitWithKcs(int unitId);
    List<KnowledgeComponent> GetKnowledgeComponentsForUnit(int unitId);
    KnowledgeComponent GetKnowledgeComponentWithInstruction(int knowledgeComponentId);
}