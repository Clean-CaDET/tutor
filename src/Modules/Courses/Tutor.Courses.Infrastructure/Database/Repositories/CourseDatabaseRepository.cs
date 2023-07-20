using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class CourseDatabaseRepository : CrudDatabaseRepository<Course, CoursesContext>, ICourseRepository
{
    public CourseDatabaseRepository(CoursesContext dbContext) : base(dbContext) {}

    public PagedResult<Course> GetPagedSortedByDate(int page, int pageSize)
    {
        var task = DbContext.Courses.OrderByDescending(c => c.StartDate).GetPaged(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public Course GetWithUnits(int courseId)
    {
        return DbContext.Courses
            .Include(c => c.KnowledgeUnits)
            .First(c => c.Id == courseId);
    }
}