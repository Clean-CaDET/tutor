using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface ILearnerService : IStakeholderService<Learner>
{
    Result<PagedResult<Learner>> GetPaged(int page, int pageSize);
    Result<PagedResult<Learner>> GetByIndexes(string[] indexes);
    Result BulkRegister(List<Learner> learners, List<string> usernames, List<string> passwords);
}