using System.Linq;
using Hasin.Core.Entities;

namespace Hasin.Infrastructure.Interfaces
{
    public interface IPhoneBookRecordRepository : IGenericRepository<PhoneBookRecord, int>
    {
        IQueryable<PhoneBookRecord> FindByTag(int tagId);
    }
}