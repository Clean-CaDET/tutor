using System.Collections.Generic;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.Domain.CourseIteration;

public interface IGroupRepository : ICrudRepository<LearnerGroup>
{
    List<LearnerGroup> GetCourseGroups(int courseId);
    Task<PagedResult<Learner>> GetLearnersWithMasteries(int courseId, int groupId, int page, int pageSize);
    List<Learner> GetLearnersInGroup(int groupId);
    void CreateBulkMemberships(IEnumerable<GroupMembership> memberships);
    void DeleteMember(int groupId, int learnerId);
}