using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portales.Servicio
{
    public interface IEntityService<T> where T : class
    {
        IQueryable<T> Get(bool noTrack);

        IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool noTrack, params Expression<Func<T, object>>[] includes);

        Task<T> FindAsync(params object[] keyValues);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<T> AddAsync(T entity);

        IEnumerable<T> Add(IEnumerable<T> collection);

        Task<T> UpdateAsync(T entity);

        Task<T> RemoveAsync(T entity);

        Task<T> RemoveAsync(params object[] keyValues);

        IEnumerable<T> Remove(IEnumerable<T> collection);

        Task<int> SaveChangesAsync();

        void Dispose();
    }
}