using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface ILearnerService
{
    Result<PagedResult<Learner>> GetPaged(int page, int pageSize);
    Result<Learner> Register(Learner learner, string username, string password);
    Result Update(Learner entity);
    Result Delete(int id);
    Result Archive(int id, bool archive);
}