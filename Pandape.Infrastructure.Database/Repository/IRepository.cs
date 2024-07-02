using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pandape.Infrastructure.Database.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T? GetById(params object[] keys);
        IQueryable<T> Include(params Expression<Func<T, object>>[] expression);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Add(IEnumerable<T> entities);       
        void Delete(IEnumerable<T> entities);
    }
}
