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
    public class PhoneBookRepositoryTests : IClassFixture<UnitOfWorkFixture>
    {
        private readonly IPhoneBookRecordRepository _phonebookRepository;
        private readonly ITagRepository _tagRepository;
        private readonly HasinContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerFactory _loggerFactory;

        public PhoneBookRepositoryTests(UnitOfWorkFixture unitOfWorkFixture)
        {
            _unitOfWork = unitOfWorkFixture.UnitOfWork;
            _phonebookRepository = unitOfWorkFixture.UnitOfWork.PhoneBookRecordRepository;
            _tagRepository = unitOfWorkFixture.UnitOfWork.TagRepository;
            _context = unitOfWorkFixture.Context;
            _loggerFactory = unitOfWorkFixture.LoggerFactory;
        }

        [Fact]
        public async Task GetPhoneBookRecords_AfterSeed_ShouldReturnSeed()
        {
            await HasinContextSeed.SeedAsync(_context, _loggerFactory);
            var list = await _phonebookRepository.GetAllAsync();
            var tags = await _tagRepository.GetAllAsync();
            
            Assert.Equal(5, list.Count);
            Assert.Equal(4, tags.Count);
        }

        [Fact]
        public async Task AddPhoneBook_WhenCommited_ShouldAddNewRecord()
        {
            var newRecord = new PhoneBookRecord("new record", "with phonenumber");
            _phonebookRepository.Add(newRecord);

            await _unitOfWork.CommitAsync();

            var allRecords = await _phonebookRepository.GetAllAsync();
            Assert.Equal(6, allRecords.Count);
        }
    }
}