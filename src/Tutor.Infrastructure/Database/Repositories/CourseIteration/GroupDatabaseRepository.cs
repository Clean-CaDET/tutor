using Microsoft.EntityFrameworkCore;
using System;
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
            .ToList();
    }

    public async Task<PagedResult<Learner>> GetLearnersWithMasteries(int courseId, int groupId, int page, int pageSize)
    {
        if (groupId == 0)
        {
            return await GetAllLearnersWithMasteriesAsync(page, pageSize, courseId);
        }
        return await GetLearnersWithMasteriesByGroupAsync(page, pageSize, groupId);
    }

    private Task<PagedResult<Learner>> GetLearnersWithMasteriesByGroupAsync(int page, int pageSize, int groupId)
    {
        return DbContext.GroupMemberships
            .Where(g => g.LearnerGroupId == groupId)
            .Include(g => g.Member)
            .ThenInclude(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.AssessmentItemMasteries)
            .Include(g => g.Member)
            .ThenInclude(l => l.KnowledgeComponentMasteries)
            .Include(g => g.Member)
            .ThenInclude(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.SessionTracker)
            .Select(g => g.Member)
            .GetPaged(page, pageSize);
    }

    private Task<PagedResult<Learner>> GetAllLearnersWithMasteriesAsync(int page, int pageSize, int courseId)
    {
        var learnerIds = GetLearnerQuery(courseId).Select(l => l.Id);

        var query = DbContext.Learners.Where(learner => learnerIds.Contains(learner.Id))
            .Include(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.AssessmentItemMasteries)
            .Include(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.SessionTracker);
       
        return query.GetPaged(page, pageSize);
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
        DbContext.SaveChanges();
    }

    public void DeleteMember(int groupId, int learnerId)
    {
        var membership = DbContext.GroupMemberships.First(m => m.LearnerGroupId == groupId && m.Member.Id == learnerId);
        if (membership == null) throw new ArgumentException("Membership not found.");
        DbContext.GroupMemberships.Remove(membership);
        DbContext.SaveChanges();
    }
}