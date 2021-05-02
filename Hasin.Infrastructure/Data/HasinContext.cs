using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Hasin.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hasin.Infrastructure
{
    public class HasinContext : DbContext
    {
        public HasinContext([NotNull] DbContextOptions options) : base(options)
        {

        }
        public DbSet<PhoneBookRecord> PhoneBookRecords { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
