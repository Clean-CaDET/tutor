using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge;

public class CourseDatabaseRepository : CrudDatabaseRepository<Course>, ICourseRepository
{
    public CourseDatabaseRepository(TutorContext dbContext) : base(dbContext) {}

    public PagedResult<Course> GetActive(int page, int pageSize)
    {
        var task = DbContext.Courses.Where(c => !c.IsArchived).GetPaged(page, pageSize);
        task.Wait();
        return task.Result;
    }
}