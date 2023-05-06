using FluentResults;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface IStakeholderService<T> where T : Stakeholder
{
    Result<T> Register(T entity, string username, string password, string userType);
    Result<T> Update(T entity);
    Result<T> Archive(int id, bool archive);
    Result Delete(int id);
}