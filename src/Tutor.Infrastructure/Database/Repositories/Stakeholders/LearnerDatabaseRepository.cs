using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Infrastructure.Database.Repositories.Stakeholders;

public class LearnerDatabaseRepository : CrudDatabaseRepository<Learner>, ILearnerRepository
{
    public LearnerDatabaseRepository(TutorContext dbContext) : base(dbContext) {}

    public PagedResult<Learner> GetByIndexes(string[] indexes)
    {
        var learners = DbContext.Learners.Where(l => indexes.Contains(l.Index)).ToList();
        return new PagedResult<Learner>(learners, learners.Count);
    }
}