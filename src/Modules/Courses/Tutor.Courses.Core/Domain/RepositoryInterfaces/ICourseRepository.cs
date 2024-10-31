using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface ICourseRepository : ICrudRepository<Course>
{
    List<Course> GetActiveAndStarted();
    PagedResult<Course> GetPagedSortedByDate(int page, int pageSize);
    Course? GetWithUnits(int courseId);
}