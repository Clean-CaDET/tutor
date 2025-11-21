using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class CourseDatabaseRepository : CrudDatabaseRepository<Course, CoursesContext>, ICourseRepository
{
    public CourseDatabaseRepository(CoursesContext dbContext) : base(dbContext) {}

    public List<Course> GetActiveAndStarted()
    {
        return DbContext.Courses
            .Where(c => c.StartDate < DateTime.UtcNow && !c.IsArchived)
            .ToList();
    }

    public List<Course> GetStarted()
    {
        return DbContext.Courses
            .Where(c => c.StartDate < DateTime.UtcNow)
            .ToList();
    }

    public PagedResult<Course> GetPagedSortedByDate(int page, int pageSize)
    {
        var task = DbContext.Courses.OrderByDescending(c => c.StartDate).GetPaged(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public Course? GetWithUnits(int courseId)
    {
        return DbContext.Courses
            .Include(c => c.KnowledgeUnits)
            .FirstOrDefault(c => c.Id == courseId);
    }

    public Course? GetWithUnitsAndReflections(int courseId)
    {
        return DbContext.Courses
            .Include(c => c.KnowledgeUnits!)
            .ThenInclude(u => u.Reflections!)
            .ThenInclude(r => r.Questions)
            .AsNoTracking()
            .FirstOrDefault(c => c.Id == courseId);
    }

    public CourseReport? GetReport(int courseId, int learnerId)
    {
        return DbContext.CourseReports
            .FirstOrDefault(r => r.CourseId == courseId && r.LearnerId == learnerId);
    }
}