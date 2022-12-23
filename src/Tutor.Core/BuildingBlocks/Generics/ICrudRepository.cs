using System.Collections.Generic;

namespace Tutor.Core.BuildingBlocks.Generics;

public interface ICrudRepository<TEntity> where TEntity : Entity
{
    PagedResult<TEntity> GetPaged(int page, int pageSize);
    TEntity Get(int id);
    TEntity Create(TEntity entity);
    void BulkCreate(List<TEntity> entities);
    TEntity Update(TEntity entity);
    void Delete(int id);
}