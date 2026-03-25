using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Elaborations.Core.Domain.ElaborationTasks;

namespace Tutor.Elaborations.Infrastructure.Database.Repositories;

public class ElaborationTaskDatabaseRepository :
    CrudDatabaseRepository<ElaborationTask, ElaborationsContext>, IElaborationTaskRepository
{
    public ElaborationTaskDatabaseRepository(ElaborationsContext dbContext) : base(dbContext) { }

    public List<ElaborationTask> GetByUnit(int unitId)
    {
        return DbContext.ElaborationTasks
            .Where(et => et.UnitId == unitId)
            .OrderBy(et => et.Order)
            .ToList();
    }
}
