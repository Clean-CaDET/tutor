﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.LearnerModel;

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

        public Learner Save(Learner learner)
        {
            _dbContext.Learners.Attach(learner);
            _dbContext.SaveChanges();
            return learner;
        }

        public async Task<PagedResult<Learner>> GetLearnersWithMasteriesAsync(int page, int pageSize)
        {
            return await _dbContext.Learners
                .Include(l => l.KnowledgeComponentMasteries)
                .ThenInclude(kcm => kcm.AssessmentMasteries)
                .Include(l => l.KnowledgeComponentMasteries)
                .ThenInclude(kcm => kcm.KnowledgeComponent)
                .GetPaged(page, pageSize);
        }
    }
}