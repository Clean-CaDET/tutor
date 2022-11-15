using System.Collections.Generic;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.Domain.CourseIteration;

public interface IGroupRepository
{
    // Should be segmented when it grows a bit more
    List<LearnerGroup> GetAssignedGroups(int instructorId, int courseId);
    Task<PagedResult<Learner>> GetLearnersWithProgressAsync(int courseId, int groupId, int page, int pageSize);
    List<Learner> GetLearnersInGroup(int groupId);
    
    int CountAllEnrollmentsInUnit(int unitId);
    List<KnowledgeUnit> GetEnrolledAndActiveUnits(int courseId, int learnerId);
    bool LearnerHasActiveEnrollment(int unitId, int learnerId);
}