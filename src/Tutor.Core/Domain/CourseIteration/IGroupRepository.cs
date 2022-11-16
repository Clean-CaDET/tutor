using System.Collections.Generic;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.Domain.CourseIteration;

public interface IGroupRepository
{
    List<LearnerGroup> GetAssignedGroups(int instructorId, int courseId);
    Task<PagedResult<Learner>> GetGroupProgressAsync(int courseId, int groupId, int page, int pageSize);
    List<Learner> GetLearnersInGroup(int groupId);
}