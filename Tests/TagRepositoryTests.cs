using System.Linq;
using System.Threading.Tasks;
using Hasin.Core.Entities;
using Hasin.Infrastructure;
using Hasin.Infrastructure.Data;
using Hasin.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Tests
{
    [Collection("uow collection")]
    public class TagRepositoryTests : IClassFixture<UnitOfWorkFixture>
    {
        private readonly ITagRepository _tagRepository;
        private readonly HasinContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerFactory _loggerFactory;

        public TagRepositoryTests(UnitOfWorkFixture unitOfWorkFixture)
        {
            _unitOfWork = unitOfWorkFixture.UnitOfWork;
            _tagRepository = unitOfWorkFixture.UnitOfWork.TagRepository;
            _context = unitOfWorkFixture.Context;
            _loggerFactory = unitOfWorkFixture.LoggerFactory;
        }

        [Fact]
        public async Task GetTagRecords_Should_ReturnSeed()
        {
            await HasinContextSeed.SeedAsync(_context, _loggerFactory);
            var tags = await _tagRepository.GetAllAsync();
            
            Assert.Equal(4, tags.Count);
        }

        [Fact]
        public async Task AddTag_Should_AddNewRecord()
        {
            var newRecord = new Tag("Tast Tag");
            _tagRepository.Add(newRecord);

            await _unitOfWork.CommitAsync();

            var allRecords = await _tagRepository.GetAllAsync();
            Assert.Equal(5, allRecords.Count);
            Assert.Equal("Tast Tag", allRecords.Last().Label);
        }
    }
}