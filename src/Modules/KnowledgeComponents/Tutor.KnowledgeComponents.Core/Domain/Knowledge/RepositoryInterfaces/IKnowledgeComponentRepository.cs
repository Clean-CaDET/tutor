using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

public interface IKnowledgeComponentRepository : ICrudRepository<KnowledgeComponent>
{
    List<KnowledgeComponent> GetByUnit(int unitId);
    List<KnowledgeComponent> GetByUnitWithAssessments(int unitId);
    List<KnowledgeComponent> GetByUnitsWithItems(List<int> unitIds);
    List<KnowledgeComponent> GetRootKcs(List<int> unitIds);
    int CountByUnit(int unitId);
}