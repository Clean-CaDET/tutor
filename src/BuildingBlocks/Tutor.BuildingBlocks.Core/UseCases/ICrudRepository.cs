using Tutor.BuildingBlocks.Core.Domain;
using FluentResults;

namespace Tutor.BuildingBlocks.Core.UseCases;

public interface ICrudRepository<TEntity> where TEntity : Entity
{
    PagedResult<TEntity> GetPaged(int page, int pageSize);
    TEntity? Get(int id);
    List<TEntity> GetMany(List<int> ids);
    TEntity Create(TEntity entity);
    List<TEntity> BulkCreate(List<TEntity> entities);
    TEntity Update(TEntity entity);
    TEntity Update(TEntity storedEntity, TEntity entity);
    TEntity UpdateWithAssociatedEntities(TEntity entity);
    void Delete(TEntity entity);
}