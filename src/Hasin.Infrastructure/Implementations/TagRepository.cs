using Hasin.Core.Entities;
using Hasin.Infrastructure;
using Hasin.Infrastructure.Implementations;
using Hasin.Infrastructure.Interfaces;

namespace tadbir.Repository.Implementations
{
    public class TagRepository : GenericRepository<Tag, int>, ITagRepository
    {
        public TagRepository(HasinContext dbContext) : base(dbContext)
        {
        }
    }
}