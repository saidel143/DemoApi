using Portales.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Portales.Repositorio
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbContext context;
        DbSet<T> dbSet;

        public Repository(IUnitOfWork unitOfWork)
        {
            context = (DbContext)unitOfWork;
            //_db.Configuration.ProxyCreationEnabled = false;
            //_db.Configuration.LazyLoadingEnabled = false;
            dbSet = context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            T record = dbSet.Add(entity);
            return record;
        }

        public virtual IEnumerable<T> Add(IEnumerable<T> collection)
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            return dbSet.AddRange(collection);
        }

        public virtual T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            T record = dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return record;
        }

        public virtual async Task<T> RemoveAsync(params object[] keyValues)
        {
            T entity = await dbSet.FindAsync(keyValues);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            T record = dbSet.Remove(entity);
            return record;
        }

        public virtual T Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            T record = dbSet.Remove(entity);
            return record;
        }

        public virtual IEnumerable<T> Remove(IEnumerable<T> collection)
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            return dbSet.RemoveRange(collection);
        }

        public virtual async Task<T> FindAsync(params object[] keyValues)
        {
            T record = await dbSet.FindAsync(keyValues);
            return record;
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                foreach (Expression<Func<T, object>> include in includes)
                {
                    dbSet.Include(include);
                }

                var obj = await dbSet.FirstOrDefaultAsync(predicate);
                return obj;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual IQueryable<T> Get(bool noTrack)
        {
            return noTrack ? dbSet.AsNoTracking() : dbSet;
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool noTrack, params Expression<Func<T, object>>[] includes)
        {
            foreach (Expression<Func<T, object>> include in includes)
            {
                dbSet.Include(include);
            }
            return noTrack ? dbSet.Where(predicate).AsNoTracking() : dbSet.Where(predicate);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
