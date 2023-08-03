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

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}