using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Infrastructure.Database.Repositories.CourseIteration;

public class GroupDatabaseRepository : CrudDatabaseRepository<LearnerGroup>, IGroupRepository
{
    public GroupDatabaseRepository(TutorContext dbContext) : base(dbContext) {}

    public List<LearnerGroup> GetCourseGroups(int courseId)
    {
        return DbContext.LearnerGroups.Where(g => g.CourseId == courseId).ToList();
    }

    public async Task<PagedResult<Learner>> GetGroupProgressAsync(int courseId, int groupId, int page, int pageSize)
    {
        if (groupId == 0)
        {
            return await GetAllLearnersAsync(page, pageSize, courseId);
        }
        return await GetLearnersByGroupAsync(page, pageSize, groupId);
    }

    private Task<PagedResult<Learner>> GetLearnersByGroupAsync(int page, int pageSize, int groupId)
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

    private Task<PagedResult<Learner>> GetAllLearnersAsync(int page, int pageSize, int courseId)
    {
        var learnerIds = DbContext.LearnerGroups.Where(lg => lg.CourseId.Equals(courseId))
            .Include(lg => lg.Membership)
            .SelectMany(m => m.Membership)
            .Select(m => m.Member.Id);

        var query = DbContext.Learners.Where(learner => learnerIds.Contains(learner.Id))
            .Include(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.AssessmentItemMasteries)
            .Include(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.SessionTracker);
       
        return query.GetPaged(page, pageSize);
    }

    public List<Learner> GetLearnersInGroup(int groupId)
    {
        return DbContext.GroupMemberships
            .Where(m => m.LearnerGroupId == groupId)
            .Include(m => m.Member)
            .Select(m => m.Member).ToList();
    }

    public void CreateBulkMemberships(IEnumerable<GroupMembership> memberships)
    {
        DbContext.AttachRange(memberships);
    }

    public void DeleteMember(int groupId, int learnerId)
    {
        var membership = DbContext.GroupMemberships.First(m => m.LearnerGroupId == groupId && m.Member.Id == learnerId);
        if (membership == null) throw new ArgumentException("Membership not found.");
        DbContext.GroupMemberships.Remove(membership);
    }
}