using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Portales.Dal;
using Portales.Repositorio;

namespace Portales.Servicio
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        IUnitOfWork unitOfWork;
        IRepository<T> repository;

        public EntityService(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            T record = repository.Add(entity);
            await SaveChangesAsync();
            return record;
        }

        public IEnumerable<T> Add(IEnumerable<T> collection)
        {
            return repository.Add(collection);
        }

        public async Task<T> FindAsync(params object[] keyValues)
        {
            return await repository.FindAsync(keyValues);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return await repository.FindAsync(predicate, includes);
        }

        public IQueryable<T> Get(bool noTrack)
        {
            return repository.Get(noTrack);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool noTrack, params Expression<Func<T, object>>[] includes)
        {
            return repository.Get(predicate, noTrack, includes);
        }

        public async Task<T> RemoveAsync(T entity)
        {
            T record = repository.Remove(entity);
            await SaveChangesAsync();
            return record;
        }

        public IEnumerable<T> Remove(IEnumerable<T> collection)
        {
            return repository.Remove(collection);
        }

        public async Task<T> RemoveAsync(params object[] keyValues)
        {
            T record = await repository.RemoveAsync(keyValues);
            await SaveChangesAsync();
            return record;
        }        

        public async Task<T> UpdateAsync(T entity)
        {
            T record = repository.Update(entity);
            await SaveChangesAsync();
            return record;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await unitOfWork.SaveChangesAsync();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
