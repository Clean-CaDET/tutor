using FluentResults;

namespace Tutor.Core.BuildingBlocks;

public interface IUnitOfWork
{
    void BeginTransaction();
    Result Save();
    Result Commit();
    Result Rollback();
}