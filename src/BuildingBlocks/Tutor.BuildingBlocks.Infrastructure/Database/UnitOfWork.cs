using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.BuildingBlocks.Infrastructure.Database;

public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void BeginTransaction()
    {
        _transaction ??= _dbContext.Database.BeginTransaction();
    }

    public Result Save()
    {
        try
        {
            _dbContext.SaveChanges();
            return Result.Ok();
        }
        catch (DbUpdateException e)
        {
            var rootError = new Error(e.Message).CausedBy(e);
            return Result.Fail(FailureCode.Conflict).WithError(rootError);
        }
    }

    public Result Commit()
    {
        if (_transaction is null) return Result.Fail("No active transaction.");

        _transaction.Commit();
        _transaction.Dispose();
        _transaction = null;
        return Result.Ok();
    }

    public Result Rollback()
    {
        if (_transaction is null) return Result.Fail("No active transaction.");

        _transaction.Rollback();
        _transaction.Dispose();
        _transaction = null;
        return Result.Ok();
    }
}