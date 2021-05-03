using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hasin.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hasin.Infrastructure.Data
{
    public class HasinContextSeed
    {
        public static async Task SeedAsync(HasinContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // catalogContext.Database.Migrate();
                if (!await catalogContext.PhoneBookRecords.AnyAsync())
                {
                    catalogContext.PhoneBookRecords.AddRange(GetPreconfiguredPhoneBookRecords());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.Tags.AnyAsync())
                {
                    catalogContext.Tags.AddRange(GetPreconfiguredTags());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<HasinContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<PhoneBookRecord> GetPreconfiguredPhoneBookRecords()
        {
            return new List<PhoneBookRecord>()
            {
                new PhoneBookRecord("Azure", "555"),
                new PhoneBookRecord(".NET", "4444"),
                new PhoneBookRecord("Visual Studio", "333"),
                new PhoneBookRecord("SQL Server", "222"),
                new PhoneBookRecord("Other", "111")
            };
        }

        static IEnumerable<Tag> GetPreconfiguredTags()
        {
            return new List<Tag>()
            {
                new Tag("Mug"),
                new Tag("T-Shirt"),
                new Tag("Sheet"),
                new Tag("USB Memory Stick")
            };
        }
    }
}