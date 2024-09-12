using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

public interface IKnowledgeComponentRepository : ICrudRepository<KnowledgeComponent>
{
    List<KnowledgeComponent> GetByUnit(int unitId);
    List<KnowledgeComponent> GetByUnitWithAssessments(int unitId);
    List<KnowledgeComponent> GetByUnits(int[] unitIds);
    List<KnowledgeComponent> GetByUnitsWithItems(int[] unitIds);
    List<KnowledgeComponent> GetRootKcs(int[] unitIds);
}