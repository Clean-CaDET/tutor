using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public interface IConceptElaborationTaskRepository : ICrudRepository<ConceptElaborationTask>
{
    ConceptElaborationTask? GetWithRecord(int id);
    List<ConceptElaborationTask> GetByUnit(int unitId);
    List<ConceptElaborationTask> GetByUnitWithRecords(int unitId);
}
