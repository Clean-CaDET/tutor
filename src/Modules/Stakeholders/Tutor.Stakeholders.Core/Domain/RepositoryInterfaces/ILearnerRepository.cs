using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

public interface ILearnerRepository : ICrudRepository<Learner>
{
    PagedResult<Learner> GetByIndexes(string[] indexes);
}