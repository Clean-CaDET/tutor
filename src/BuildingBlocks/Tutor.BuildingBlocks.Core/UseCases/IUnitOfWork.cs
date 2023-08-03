using FluentResults;

namespace Tutor.BuildingBlocks.Core.UseCases;

public interface IUnitOfWork
{
    void BeginTransaction();
    Result Save();
    Result Commit();
    Result Rollback();
}