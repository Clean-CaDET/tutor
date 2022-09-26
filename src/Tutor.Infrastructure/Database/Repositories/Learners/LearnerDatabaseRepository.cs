using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel;

namespace Tutor.Infrastructure.Database.Repositories.Learners
{
    public class LearnerDatabaseRepository : ILearnerRepository
    {
        private readonly TutorContext _dbContext;

        public LearnerDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Learner GetByUserId(int userId)
        {
            return _dbContext.Learners.FirstOrDefault(learner => learner.UserId.Equals(userId));
        }

        public Learner GetByIndex(string index)
        {
            return _dbContext.Learners.FirstOrDefault(learner => learner.Index.Equals(index));
        }

        public List<Learner> GetByGroupId(int groupId)
        {
            return _dbContext.GroupMemberships
                .Where(m => m.LearnerGroupId == groupId)
                .Include(m => m.Learner)
                .Select(m => m.Learner).ToList();
        }

        public Learner Save(Learner learner)
        {
            _dbContext.Learners.Attach(learner);
            _dbContext.SaveChanges();
            return learner;
        }

        public async Task<PagedResult<Learner>> GetLearnersWithMasteriesAsync(int page, int pageSize, int groupId)
        {
            if (groupId == 0)
            {
                return await GetAllLearnersAsync(page, pageSize);
            }
            return await GetLearnersByGroupAsync(page, pageSize, groupId);
        }

        private Task<PagedResult<Learner>> GetLearnersByGroupAsync(int page, int pageSize, int groupId)
        {
            return _dbContext.GroupMemberships
                .Where(g => g.LearnerGroupId == groupId)
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

        private async Task<PagedResult<Learner>> GetAllLearnersAsync(int page, int pageSize)
        {
            return await _dbContext.Learners
                .Include(l => l.KnowledgeComponentMasteries)
                .ThenInclude(kcm => kcm.AssessmentItemMasteries)
                .Include(l => l.KnowledgeComponentMasteries)
                .ThenInclude(kcm => kcm.KnowledgeComponent)
                .Include(l => l.KnowledgeComponentMasteries)
                .ThenInclude(kcm => kcm.SessionTracker)
                .GetPaged(page, pageSize);
        }

        public List<LearnerGroup> GetGroups()
        {
            return _dbContext.LearnerGroups.ToList();
        }

        public int CountEnrolledInUnit(int unitId, List<int> learnerIds)
        {
            if (learnerIds == null)
                return _dbContext.UnitEnrollments.Count(enrollment => enrollment.KnowledgeUnit.Id == unitId);
            return _dbContext.UnitEnrollments.Count(enrollment => 
                enrollment.KnowledgeUnit.Id == unitId && learnerIds.Contains(enrollment.LearnerId));
        }
    }
}