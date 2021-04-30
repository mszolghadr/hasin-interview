using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hasin.Core.Entities;
using Hasin.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hasin.Infrastructure.Implementations
{
    public abstract class GenericRepository<T, K> : IGenericRepository<T, K> where T : BaseEntity
    {
        protected readonly HasinContext _dbContext;

        public GenericRepository(HasinContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public virtual async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual T Get(K key)
        {
            return _dbContext.Set<T>().Find(key);
        }

        public virtual async Task<T> GetAsync(K key, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FindAsync(new object[] { key }, cancellationToken);
        }

        public virtual T Add(T t)
        {
            _dbContext.Set<T>().Add(t);
            return t;
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual async Task DeleteAsync(K key, CancellationToken cancellationToken)
        {
            T exist = await _dbContext.Set<T>().FindAsync(new object[] { key }, cancellationToken);
            if (exist != null)
            {
                _dbContext.Set<T>().Remove(exist);
            }
        }

        public virtual T Update(T t, K key)
        {
            if (t == null)
                return null;
            T exist = _dbContext.Set<T>().Find(key);
            if (exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(t);
            }
            return exist;
        }

        public virtual async Task<T> UpdateAsync(T t, K key, CancellationToken cancellationToken)
        {
            if (t == null)
                return null;
            T exist = await _dbContext.Set<T>().FindAsync(new object[] { key }, cancellationToken);
            if (exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(t);
            }
            return exist;
        }
    }
}