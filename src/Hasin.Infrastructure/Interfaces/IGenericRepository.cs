using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hasin.Core.Entities;

namespace Hasin.Infrastructure.Interfaces
{
    public interface IGenericRepository<T, TKey> where T : BaseEntity
    {
        T Add(T t);

        void Delete(T entity);

        Task DeleteAsync(TKey key, CancellationToken cancellationToken = default);

        T Get(TKey key);

        IQueryable<T> GetAll();

        Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<T> GetAsync(TKey key, CancellationToken cancellationToken = default);

        T Update(T t, TKey key);

        Task<T> UpdateAsync(T t, TKey key, CancellationToken cancellationToken = default);
    }

}