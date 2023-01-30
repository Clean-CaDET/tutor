using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Infrastructure.Database.Repositories.CourseIteration;

public class GroupDatabaseRepository : CrudDatabaseRepository<LearnerGroup>, IGroupRepository
{
    public GroupDatabaseRepository(TutorContext dbContext) : base(dbContext) {}

    public GroupMembership GetGroupMembership(int groupId, int learnerId)
    {
        return DbContext.GroupMemberships.FirstOrDefault(m => m.LearnerGroupId == groupId && m.Member.Id == learnerId);
    }

    public List<LearnerGroup> GetCourseGroups(int courseId)
    {
        return DbContext.LearnerGroups.Where(g => g.CourseId == courseId).ToList();
    }

    public List<KnowledgeComponentMastery> GetMasteriesForLearnersAndUnit(int unitId, int[] learnerIds)
    {
        var kcIds = DbContext.KnowledgeComponents
            .Where(kc => kc.KnowledgeUnitId == unitId)
            .Select(kc => kc.Id);

        return DbContext.KcMasteries
            .Where(kcm => learnerIds.Contains(kcm.LearnerId) && kcIds.Contains(kcm.KnowledgeComponentId))
            .Include(kcm => kcm.AssessmentItemMasteries)
            .Include(kcm => kcm.SessionTracker)
            .ToList();
    }
    
    private IQueryable<Learner> GetLearnerQuery(int courseId)
    {
        return DbContext.LearnerGroups.Where(lg => lg.CourseId.Equals(courseId))
            .Include(lg => lg.Membership)
            .SelectMany(m => m.Membership)
            .Select(m => m.Member);
    }

    public Task<PagedResult<Learner>> GetLearnersInCourseAsync(int courseId, int page, int pageSize)
    {
        return GetLearnerQuery(courseId).GetPaged(page, pageSize);
    }

    public Task<PagedResult<Learner>> GetLearnersInGroupAsync(int groupId, int page, int pageSize)
    {
        return DbContext.GroupMemberships
            .Where(m => m.LearnerGroupId == groupId)
            .Include(m => m.Member)
            .Select(m => m.Member).GetPaged(page, pageSize);
    }

    public void CreateBulkMemberships(IEnumerable<GroupMembership> memberships)
    {
        DbContext.AttachRange(memberships);
    }

    public void DeleteMember(GroupMembership membership)
    {
        DbContext.GroupMemberships.Remove(membership);
    }
}