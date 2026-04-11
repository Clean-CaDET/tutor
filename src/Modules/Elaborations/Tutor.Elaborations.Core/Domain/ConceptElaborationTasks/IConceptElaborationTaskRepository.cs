using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public interface IConceptElaborationTaskRepository : ICrudRepository<ConceptElaborationTask>
{
    List<ConceptElaborationTask> GetByUnit(int unitId);
}
