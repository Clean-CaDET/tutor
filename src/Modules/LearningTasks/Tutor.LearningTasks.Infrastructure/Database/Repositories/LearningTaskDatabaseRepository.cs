using System.Linq.Expressions;
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
        return DbContext.LearningTasks.Where(t => t.Id == id)
            .Include(t => t.Steps!)
                .ThenInclude(s => s.Standards)
            .FirstOrDefault();
    }

    public List<LearningTask> GetByUnit(int unitId)
    {
        return GetTasksWhere(t => t.UnitId == unitId);
    }

    public List<LearningTask> GetByUnits(int[] unitIds)
    {
        return GetTasksWhere(t => unitIds.Contains(t.UnitId));
    }

    public List<LearningTask> GetNonTemplateByUnit(int unitId)
    {
        return GetTasksWhere(t => t.UnitId == unitId && !t.IsTemplate);
    }

    public List<LearningTask> GetNonTemplateByUnits(int[] unitIds)
    {
        return DbContext.LearningTasks
            .Where(t => unitIds.Contains(t.UnitId) && !t.IsTemplate)
            .ToList();
    }

    private List<LearningTask> GetTasksWhere(Expression<Func<LearningTask, bool>> expression)
    {
        return DbContext.LearningTasks.Where(expression)
            .Include(t => t.Steps!)
            .ThenInclude(s => s.Standards)
            .ToList();
    }
}
