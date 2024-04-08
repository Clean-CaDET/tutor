using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Core.Domain;
using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.BuildingBlocks.Infrastructure.Database;

public class CrudDatabaseRepository<TEntity, TDbContext> : ICrudRepository<TEntity>
    where TEntity : Entity
    where TDbContext : DbContext
{
    protected readonly TDbContext DbContext;
    private readonly DbSet<TEntity> _dbSet;

    public CrudDatabaseRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
        _dbSet = DbContext.Set<TEntity>();
    }

    public PagedResult<TEntity> GetPaged(int page, int pageSize)
    {
        var task = _dbSet.GetPagedById(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public TEntity? Get(int id)
    {
        return _dbSet.Find(id);
    }

    public List<TEntity> GetMany(List<int> ids)
    {
        return _dbSet.Where(e => ids.Contains(e.Id)).ToList();
    }

    public TEntity Create(TEntity entity)
    {
        _dbSet.Add(entity);
        return entity;
    }

    public List<TEntity> BulkCreate(List<TEntity> entities)
    {
        _dbSet.AddRange(entities);
        return entities;
    }

    public TEntity Update(TEntity entity)
    {
        DbContext.Update(entity);
        return entity;
    }

    public TEntity Update(TEntity storedEntity, TEntity entity)
    {
        DbContext.Entry(storedEntity).CurrentValues.SetValues(entity);
        return entity;
    }

    /// <summary>
    /// Method for directly updating an existing entity.
    /// This method is intended for cases where it's necessary to perform a direct update of an entity that has already been loaded, 
    /// especially when associated entities are present.
    /// After applying changes to the provided entity, the method saves the updated entity with associated entities to the database.
    /// </summary>
    public TEntity UpdateWithAssociatedEntities(TEntity entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
        DbContext.SaveChanges();
        return entity;
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}