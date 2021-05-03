using System;
using System.Collections.Generic;
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
    public class PhoneBookRepositoryTests : IClassFixture<UnitOfWorkFixture>
    {
        private readonly IPhoneBookRecordRepository _phonebookRepository;
        private readonly HasinContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerFactory _loggerFactory;

        public PhoneBookRepositoryTests(UnitOfWorkFixture unitOfWorkFixture)
        {
            _unitOfWork = unitOfWorkFixture.UnitOfWork;
            _phonebookRepository = unitOfWorkFixture.UnitOfWork.PhoneBookRecordRepository;
            _context = unitOfWorkFixture.Context;
            _loggerFactory = unitOfWorkFixture.LoggerFactory;
        }

        [Fact]
        public async Task AddPhoneBook_Should_AddNewRecord()
        {
            var newRecord = new PhoneBookRecord("new record", "with phonenumber");
            _phonebookRepository.Add(newRecord);

            await _unitOfWork.CommitAsync();

            var addedRecord = await _phonebookRepository.GetAsync(newRecord.Id);
            Assert.Equal("with phonenumber", addedRecord.PhoneNumber);
        }


        [Fact]
        public async Task FindPhoneBookByTag_Should_FindRecord()
        {
            var newRecord = new PhoneBookRecord("new record", "with tag");
            newRecord.UpdateTags(new List<int> { 1 });
            _phonebookRepository.Add(newRecord);

            await _unitOfWork.CommitAsync();

            var addedRecord = await _phonebookRepository.GetAsync(newRecord.Id);
            Assert.Equal(1, addedRecord.PhoneBookTags.Count);
            Assert.Equal("with tag", addedRecord.PhoneNumber);
        }
    }
}