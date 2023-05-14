using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface ILearnerService : IStakeholderService<Learner>
{
    Result<PagedResult<Learner>> GetPaged(int page, int pageSize);
    Result<(PagedResult<Learner> learners, List<UserRole> roles)> GetPagedWithRole(int page, int pageSize);
    Result<PagedResult<Learner>> GetByIndexes(string[] indexes);
    Result<List<Learner>> BulkRegister(List<Learner> learners, List<string> usernames, List<string> passwords, UserRole role);
}