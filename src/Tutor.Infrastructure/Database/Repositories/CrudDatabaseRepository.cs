using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Infrastructure.Database.Repositories
{
    public class CrudDatabaseRepository<T> : ICrudRepository<T> where T : Entity
    {
        protected readonly TutorContext DbContext;

        public CrudDatabaseRepository(TutorContext dbContext)
        {
            DbContext = dbContext;
        }

        public T Get(int id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public T Create(T entity)
        {
            DbContext.Set<T>().Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = DbContext.Set<T>().Find(id);
            if (entity == null) throw new ArgumentException("Entity not found: " + id);
            DbContext.Set<T>().Remove(entity);
        }
    }
}
