using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LearningTasks.Core.Domain.LearningTasks;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Infrastructure.Database.Repositories;

public class LearningTaskDatabaseRepository : CrudDatabaseRepository<LearningTask, LearningTasksContext>, ILearningTaskRepository
{
    public LearningTaskDatabaseRepository(LearningTasksContext dbContext) : base(dbContext) {}

    public new LearningTask? Get(int id)
    {
        return DbContext.LearningTasks.Where(l => l.Id == id)
            .Include(l => l.Steps!)
                .ThenInclude(s => s.Standards)
            .FirstOrDefault();
    }

    public List<LearningTask> GetForUnit(int unitId)
    {
        return DbContext.LearningTasks.Where(l => l.UnitId == unitId)
            .Include(l => l.Steps!)
                .ThenInclude(s => s.Standards)
            .ToList();
    }

    public List<LearningTask> GetForUnits(List<int> unitIds)
    {
        return DbContext.LearningTasks.Where(t => unitIds.Contains(t.UnitId))
                .Include(l => l.Steps!)
                    .ThenInclude(s => s.Standards)
                .ToList();
    }
}
