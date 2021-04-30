using System.Threading;
using System.Threading.Tasks;
using Hasin.Infrastructure.Interfaces;

namespace Hasin.Infrastructure
{
    public interface IUnitOfWork
    {
        IPhoneBookRecordRepository PhoneBookRecordRepository { get; }

        void Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}