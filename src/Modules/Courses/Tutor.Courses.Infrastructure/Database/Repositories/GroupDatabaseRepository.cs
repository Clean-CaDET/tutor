using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class GroupDatabaseRepository : CrudDatabaseRepository<LearnerGroup, CoursesContext>, IGroupRepository
{
    public GroupDatabaseRepository(CoursesContext dbContext) : base(dbContext) {}

    public List<LearnerGroup> GetCourseGroups(int courseId)
    {
        return DbContext.LearnerGroups.Where(g => g.CourseId == courseId).ToList();
    }

    public PagedResult<Course> GetEnrolledCourses(int learnerId, int page, int pageSize)
    {
        var task = DbContext.LearnerGroups
            .Where(lg => EF.Functions.JsonContains(lg.LearnerIds, $"{learnerId}"))
            .Select(lg => lg.Course).Where(c => !c.IsArchived)
            .Distinct().GetPaged(page, pageSize);
        task.Wait();
        return task.Result!;
    }

    public Course? GetEnrolledCourse(int courseId, int learnerId)
    {
        return DbContext.LearnerGroups
            .Where(lg => EF.Functions.JsonContains(lg.LearnerIds, $"{learnerId}"))
            .Select(lg => lg.Course)
            .FirstOrDefault(c => c.Id == courseId && !c.IsArchived);
    }
}