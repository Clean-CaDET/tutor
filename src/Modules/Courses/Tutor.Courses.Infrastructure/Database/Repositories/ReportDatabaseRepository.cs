using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.Domain.Report;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class ReportDatabaseRepository : CrudDatabaseRepository<CourseReport, CoursesContext>, IReportRepository
{
    public ReportDatabaseRepository(CoursesContext dbContext): base(dbContext) {}
    
    public CourseReport? Get(int courseId, int learnerId)
    {
        return DbContext.CourseReports
            .FirstOrDefault(r => r.CourseId == courseId && r.LearnerId == learnerId);
    }

    public List<CourseReport> GetByLearners(int[] learnerIds)
    {
        return DbContext.CourseReports
            .Where(r => learnerIds.Contains(r.LearnerId))
            .ToList();
    }
}