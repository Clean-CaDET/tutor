using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TutorContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            if (_transaction is null)
            {
                _transaction = _dbContext.Database.BeginTransaction();
            }
        }

        public Result Save()
        {
            try
            {
                _dbContext.SaveChanges();
                return Result.Ok();
            }
            catch (DbUpdateException)
            {
                return Result.Fail(FailureCode.Conflict);
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
}
