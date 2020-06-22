using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.Infrastructure;

namespace TrueForm.DataLayer.Infrastructure
{
    public interface IGenericRepository<T> where T : IBaseEntity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        int Count(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
    }
}
