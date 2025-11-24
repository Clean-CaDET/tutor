using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.Core.Domain.Report;

namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface ICourseRepository : ICrudRepository<Course>
{
    List<Course> GetActiveAndStarted();
    List<Course> GetStarted();
    PagedResult<Course> GetPagedSortedByDate(int page, int pageSize);
    Course? GetWithUnits(int courseId);
    CourseReport? GetReport(int courseId, int learnerId);
}