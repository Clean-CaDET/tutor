using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IGroupRepository : ICrudRepository<LearnerGroup>
{
    List<LearnerGroup> GetCourseGroups(int courseId);
}