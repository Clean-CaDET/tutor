using System.Linq;
using FluentResults;
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

    public Result<Learner> GetById(int learnerId)
    {
        return DbContext.Learners.First(l => l.Id.Equals(learnerId));
    }
}