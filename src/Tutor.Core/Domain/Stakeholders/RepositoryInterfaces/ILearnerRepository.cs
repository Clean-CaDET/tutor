using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;

namespace Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

public interface ILearnerRepository : ICrudRepository<Learner>
{
    PagedResult<Learner> GetByIndexes(string[] indexes);
}