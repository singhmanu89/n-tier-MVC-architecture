using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TrueForm.BusinessObjects.Infrastructure;

namespace TrueForm.DataLayer.Infrastructure
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class, IBaseEntity
    {
        protected readonly IDbSet<T> Dbset;
        
        protected TrueFormDbContext Context;

        public GenericRepository(TrueFormDbContext context)
        {
            Context = context;
            Dbset = Context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Dbset.AsEnumerable();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            var query = Dbset.Where(predicate);
            return query;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Count(predicate);
        }

        public virtual T Add(T entity)
        {
            return Dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return Dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}