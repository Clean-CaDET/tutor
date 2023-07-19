using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IGroupRepository : ICrudRepository<LearnerGroup>
{
    GroupMembership GetGroupMembership(int groupId, int learnerId);
    List<LearnerGroup> GetCourseGroups(int courseId);
    List<int> GetLearnerIdsInGroup(int groupId);
    List<int> GetLearnerIdsInCourse(int courseId);
    void CreateBulkMemberships(IEnumerable<GroupMembership> memberships);
    void DeleteMember(GroupMembership membership);
}