using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge;

public class CourseDatabaseRepository : CrudDatabaseRepository<Course>, ICourseRepository
{
    public CourseDatabaseRepository(TutorContext dbContext) : base(dbContext) {}

    public PagedResult<Course> GetPagedSortedByDate(int page, int pageSize)
    {
        var task = DbContext.Courses.OrderByDescending(c => c.StartDate).GetPaged(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public Course GetFullCourse(int courseId)
    {
        return DbContext.Courses
            .Include(c => c.KnowledgeUnits)
            .ThenInclude(u => u.KnowledgeComponents)
            .ThenInclude(kc => kc.InstructionalItems)
            .Include(c => c.KnowledgeUnits)
            .ThenInclude(u => u.KnowledgeComponents)
            .ThenInclude(kc => kc.AssessmentItems)
            .FirstOrDefault(c => c.Id == courseId);
    }
}