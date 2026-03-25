using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Elaborations.Core.Domain.ElaborationTasks;

public interface IElaborationTaskRepository : ICrudRepository<ElaborationTask>
{
    List<ElaborationTask> GetByUnit(int unitId);
}
