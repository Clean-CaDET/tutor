namespace Tutor.Core.BuildingBlocks
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
