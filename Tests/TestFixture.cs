using System;
using Microsoft.EntityFrameworkCore;
using tadbir.Data;
using tadbir.Entities;
using tadbir.Repository;
using Xunit;
namespace Tests
{
    public class TestFixture : IUseFixture<HasinContext>
    {
        private static TadbirDbContext _context;

        public TestFixture()
        {
        }

        public static TadbirDbContext Context
        {
            get
            {
                var options = new DbContextOptionsBuilder<TadbirDbContext>()
                 .UseInMemoryDatabase(databaseName: "InterviewDataBase")
                 .Options;
                return _context ??= new TadbirDbContext(options);
            }
        }
    }
}
