using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Tutor.Stakeholders.Infrastructure.Database.Repositories;

public class LearnerDatabaseRepository : CrudDatabaseRepository<Learner, StakeholdersContext>, ILearnerRepository
{
    public LearnerDatabaseRepository(StakeholdersContext dbContext) : base(dbContext) {}

    public PagedResult<Learner> GetByIndexes(string[] indexes)
    {
        var learners = DbContext.Learners.Where(l => indexes.Contains(l.Index)).ToList();
        return new PagedResult<Learner>(learners, learners.Count);
    }
}