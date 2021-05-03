using System.Linq;
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

        public IQueryable<PhoneBookRecord> FindByTag(int tagId)
        {
            return from r in _dbContext.PhoneBookRecords
                   join pt in _dbContext.Set<PhoneBookTag>() on new { rid = r.Id, tid = tagId } equals new { rid = pt.PhoneBookRecordId, tid = pt.TagId }
                   select r;
        }
    }
}