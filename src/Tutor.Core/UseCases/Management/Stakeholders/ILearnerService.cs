using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface ILearnerService
{
    Result<PagedResult<Learner>> GetPaged(int page, int pageSize);
    Result<Learner> Register(Learner learner, string username, string password);
    Result BulkRegister(List<Learner> learners, List<string> usernames, List<string> passwords);
    Result<Learner> Update(Learner entity);
    Result Delete(int id);
    Result<Learner> Archive(int id, bool archive);
}