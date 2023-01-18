using FluentResults;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface IStakeholderService<T> where T : Stakeholder
{
    Result<T> Register(T stakeholder, string username, string password);
    Result<T> Update(T stakeholder);
    Result<T> Archive(int id, bool archive);
    Result Delete(int id);
}