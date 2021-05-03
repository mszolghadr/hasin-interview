using System;
using Hasin.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
namespace Tests
{
    public class UnitOfWorkFixture : IDisposable
    {
        public UnitOfWorkFixture()
        {
            var options = new DbContextOptionsBuilder<HasinContext>()
             .UseInMemoryDatabase(databaseName: "TestDatabase")
             .Options;
            Context = new HasinContext(options);
            UnitOfWork = new UnitOfWork(Context);

            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            LoggerFactory = serviceProvider.GetService<ILoggerFactory>();
        }

        public UnitOfWork UnitOfWork { get; private set; }
        public HasinContext Context { get; private set; }
        public ILoggerFactory LoggerFactory { get; private set; }

        public void Dispose()
        {
            UnitOfWork.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
