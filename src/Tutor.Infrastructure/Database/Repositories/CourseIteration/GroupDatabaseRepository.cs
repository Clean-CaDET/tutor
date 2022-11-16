using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Infrastructure.Database.Repositories.CourseIteration;

public class GroupDatabaseRepository : IGroupRepository
{
    private readonly TutorContext _dbContext;

    public GroupDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<LearnerGroup> GetAssignedGroups(int instructorId, int courseId)
    {
        return _dbContext.LearnerGroups
            .Where(lg => lg.Course.Id.Equals(courseId))
            .Include(lg => lg.Membership
                .Where(m => m.Instructor.Id.Equals(instructorId))).ToList();
    }
    
    public async Task<PagedResult<Learner>> GetLearnersWithProgressAsync(int courseId, int groupId, int page, int pageSize)
    {
        if (groupId == 0)
        {
            return await GetAllLearnersAsync(page, pageSize, courseId);
        }
        return await GetLearnersByGroupAsync(page, pageSize, groupId);
    }

    private Task<PagedResult<Learner>> GetLearnersByGroupAsync(int page, int pageSize, int groupId)
    {
        return _dbContext.GroupMemberships
            .Where(g => g.LearnerGroupId == groupId && g.Role.Equals(Role.Learner))
            .Include(g => g.Learner)
            .ThenInclude(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.AssessmentItemMasteries)
            .Include(g => g.Learner)
            .ThenInclude(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.KnowledgeComponent)
            .Include(g => g.Learner)
            .ThenInclude(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.SessionTracker)
            .Select(g => g.Learner)
            .GetPaged(page, pageSize);
    }

    private Task<PagedResult<Learner>> GetAllLearnersAsync(int page, int pageSize, int courseId)
    {
        return _dbContext.LearnerGroups.Where(lg => lg.Course.Id.Equals(courseId))
            .Include(lg => lg.Membership)
            .ThenInclude(m => m.Learner)
            .ThenInclude(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.AssessmentItemMasteries)
            .Include(lg => lg.Membership)
            .ThenInclude(m => m.Learner)
            .ThenInclude(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.KnowledgeComponent)
            .Include(lg => lg.Membership)
            .ThenInclude(m => m.Learner)
            .ThenInclude(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.SessionTracker)
            .SelectMany(lg => lg.Membership.Select(m => m.Learner)).Where(l => l != null).Distinct()
            .GetPaged(page, pageSize);
    }

    public List<Learner> GetLearnersInGroup(int groupId)
    {
        return _dbContext.GroupMemberships
            .Where(m => m.Role.Equals(Role.Learner) && m.LearnerGroupId == groupId)
            .Include(m => m.Learner)
            .Select(m => m.Learner).ToList();
    }

    public int CountAllEnrollmentsInUnit(int unitId)
    {
        return _dbContext.UnitEnrollments.Count(enrollment => enrollment.KnowledgeUnit.Id == unitId);
    }

    public List<KnowledgeUnit> GetEnrolledAndActiveUnits(int courseId, int learnerId)
    {
        return _dbContext.UnitEnrollments
            .Where(ue => ue.LearnerId.Equals(learnerId)
                         && ue.KnowledgeUnit.Course.Id.Equals(courseId)
                         && ue.Status.Equals(EnrollmentStatus.Active))
            .Include(ue => ue.KnowledgeUnit)
            .Select(ue => ue.KnowledgeUnit).ToList();
    }

    public bool LearnerHasActiveEnrollment(int unitId, int learnerId)
    {
        return _dbContext.UnitEnrollments.Any(u => u.Status == EnrollmentStatus.Active &&
                        u.KnowledgeUnit.Id == unitId && u.LearnerId == learnerId);
    }
}