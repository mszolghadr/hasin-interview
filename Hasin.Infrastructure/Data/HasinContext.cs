using System;
using System.Diagnostics.CodeAnalysis;
using Hasin.Core.Entities.PhoneBookRecordAggregate;
using Microsoft.EntityFrameworkCore;

namespace Hasin.Infrastructure
{
    public class HasinContext : DbContext
    {
        public HasinContext([NotNull] DbContextOptions options) : base(options)
        {

        }
        public DbSet<PhoneBookRecord> PhoneBookRecords { get; set; }
    }
}
