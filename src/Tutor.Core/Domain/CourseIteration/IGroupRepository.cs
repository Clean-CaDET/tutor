using System.Collections.Generic;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.Domain.CourseIteration;

public interface IGroupRepository : ICrudRepository<LearnerGroup>
{
    GroupMembership GetGroupMembership(int groupId, int learnerId);
    List<LearnerGroup> GetCourseGroups(int courseId);
    Task<PagedResult<Learner>> GetLearnersInCourseAsync(int courseId, int page, int pageSize);
    Task<PagedResult<Learner>> GetLearnersInGroupAsync(int groupId, int page, int pageSize);
    List<KnowledgeComponentMastery> GetMasteriesForLearnersAndUnit(int unitId, int[] learnerIds);
    void CreateBulkMemberships(IEnumerable<GroupMembership> memberships);
    void DeleteMember(GroupMembership membership);
}