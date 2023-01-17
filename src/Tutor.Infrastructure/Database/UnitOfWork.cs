using Tutor.Core.BuildingBlocks;

namespace Tutor.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TutorContext _dbContext;

        public UnitOfWork(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
            => _dbContext.SaveChanges();

        public void Rollback()
            => _dbContext.Dispose();
    }
}
