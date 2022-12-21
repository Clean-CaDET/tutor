using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Infrastructure.Database.Repositories.CourseIteration;

public class GroupDatabaseRepository : CrudDatabaseRepository<LearnerGroup>, IGroupRepository
{
    private readonly TutorContext _dbContext;

    public GroupDatabaseRepository(TutorContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public List<LearnerGroup> GetCourseGroups(int courseId)
    {
        return _dbContext.LearnerGroups.Where(g => g.CourseId == courseId).ToList();
    }

    public List<LearnerGroup> GetAssignedGroups(int instructorId, int courseId)
    {
        return _dbContext.LearnerGroups
            .Where(lg => lg.CourseId.Equals(courseId))
            .Include(lg => lg.Membership
                .Where(m => m.Member.Id.Equals(instructorId))).ToList();
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
        return _dbContext.GroupMemberships
            .Where(g => g.LearnerGroupId == groupId)
            .Include(g => g.Member)
            .ThenInclude(l => ((Learner)l).KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.AssessmentItemMasteries)
            .Include(g => g.Member)
            .ThenInclude(l => ((Learner)l).KnowledgeComponentMasteries)
            .Include(g => g.Member)
            .ThenInclude(l => ((Learner)l).KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.SessionTracker)
            .Select(g => (Learner)g.Member)
            .GetPaged(page, pageSize);
    }

    private Task<PagedResult<Learner>> GetAllLearnersAsync(int page, int pageSize, int courseId)
    {
        var learnerIds = _dbContext.LearnerGroups.Where(lg => lg.CourseId.Equals(courseId))
            .Include(lg => lg.Membership)
            .SelectMany(m => m.Membership)
            .Select(m => m.Member.Id);

        var query = _dbContext.Learners.Where(learner => learnerIds.Contains(learner.Id))
            .Include(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.AssessmentItemMasteries)
            .Include(l => l.KnowledgeComponentMasteries)
            .ThenInclude(kcm => kcm.SessionTracker);
       
        return query.GetPaged(page, pageSize);
    }

    public List<Learner> GetLearnersInGroup(int groupId)
    {
        return _dbContext.GroupMemberships
            .Where(m => m.LearnerGroupId == groupId)
            .Include(m => m.Member)
            .Select(m => m.Member).ToList();
    }
}