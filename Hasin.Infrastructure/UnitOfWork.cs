using System.Threading.Tasks;
using tadbir.Repository.Implementations;
using System;
using System.Threading;
using Hasin.Infrastructure.Interfaces;

namespace Hasin.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed = false;
        private readonly HasinContext _dbContext;

        public UnitOfWork(HasinContext dbContext)
        {
            _dbContext = dbContext;
        }
        private IPhoneBookRecordRepository _phoneBookRecordRepository;
        private ITagRepository _tagRepository;

        public IPhoneBookRecordRepository PhoneBookRecordRepository => _phoneBookRecordRepository ??= new PhoneBookRecordRepository(_dbContext);
        public ITagRepository TagRepository => _tagRepository ??= new TagRepository(_dbContext);

        public void Commit() => _dbContext.SaveChanges();
        public async Task<int> CommitAsync(CancellationToken cancellationToken) => await _dbContext.SaveChangesAsync(cancellationToken);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _dbContext?.Dispose();
            }

            _disposed = true;
        }
    }
}