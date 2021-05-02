using System.Threading;
using System.Threading.Tasks;
using Hasin.Core.Entities;
using Hasin.Infrastructure;
using Hasin.Infrastructure.Implementations;
using Hasin.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tadbir.Repository.Implementations
{
    public class PhoneBookRecordRepository : GenericRepository<PhoneBookRecord, int>, IPhoneBookRecordRepository
    {
        public PhoneBookRecordRepository(HasinContext dbContext) : base(dbContext)
        {
        }

        public override async Task<PhoneBookRecord> GetAsync(int phoneBookRecordId, CancellationToken cancellationToken)
        {
            return await _dbContext.PhoneBookRecords.Include(i => i.PhoneBookTags).FirstOrDefaultAsync(i => i.Id == phoneBookRecordId, cancellationToken);
        }
    }
}