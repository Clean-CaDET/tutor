using System.Collections.Generic;

namespace Tutor.Core.BuildingBlocks;

public interface ICrudRepository<TEntity> where TEntity : Entity
{
    TEntity Get(int id);
    List<TEntity> GetAll();
    TEntity Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
}