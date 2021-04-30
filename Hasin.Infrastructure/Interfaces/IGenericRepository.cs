using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hasin.Core.Entities;

namespace Hasin.Infrastructure.Interfaces
{
    public interface IGenericRepository<T, K> where T : BaseEntity
    {
        T Add(T t);

        void Delete(T entity);

        Task DeleteAsync(K key, CancellationToken cancellationToken = default);

        T Get(K key);

        IQueryable<T> GetAll();

        Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<T> GetAsync(K key, CancellationToken cancellationToken = default);

        T Update(T t, K key);

        Task<T> UpdateAsync(T t, K key, CancellationToken cancellationToken = default);
    }

}