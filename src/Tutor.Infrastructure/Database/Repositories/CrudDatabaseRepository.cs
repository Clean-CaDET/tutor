using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;

namespace Tutor.Infrastructure.Database.Repositories;

public class CrudDatabaseRepository<T> : ICrudRepository<T> where T : Entity
{
    protected readonly TutorContext DbContext;
    private readonly DbSet<T> _dbSet;

    public CrudDatabaseRepository(TutorContext dbContext)
    {
        DbContext = dbContext;
        _dbSet = DbContext.Set<T>();
    }

    public PagedResult<T> GetPaged(int page, int pageSize)
    {
        var task = _dbSet.OrderByDescending(e => e.Id).GetPaged(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public T Get(int id)
    {
        return _dbSet.Find(id);
    }

    public T Create(T entity)
    {
        _dbSet.Attach(entity);
        DbContext.SaveChanges();
        return entity;
    }

    public void BulkCreate(List<T> entities)
    {
        _dbSet.AttachRange(entities);
        DbContext.SaveChanges();
    }

    public T Update(T entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
        DbContext.SaveChanges();
        return entity;
    }

    public void Delete(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity == null) throw new ArgumentException("Entity not found: " + id);
        _dbSet.Remove(entity);
        DbContext.SaveChanges();
    }
}