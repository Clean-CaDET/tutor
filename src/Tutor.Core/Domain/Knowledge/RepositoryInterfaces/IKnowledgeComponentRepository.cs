using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Knowledge.RepositoryInterfaces;

public interface IKnowledgeComponentRepository : ICrudRepository<KnowledgeComponent>
{
    List<KnowledgeComponent> GetKnowledgeComponentsForUnit(int unitId);
    KnowledgeComponent GetKnowledgeComponentWithInstruction(int knowledgeComponentId);
    List<KnowledgeComponent> GetRootKcs(int[] unitIds);
}