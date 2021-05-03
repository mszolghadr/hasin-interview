using Hasin.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hasin.Infrastructure.Data.Config
{
    public class PhoneBookRecordConfig : IEntityTypeConfiguration<PhoneBookRecord>
    {
        public void Configure(EntityTypeBuilder<PhoneBookRecord> builder)
        {
            // builder.OwnsMany(r => r.PhoneBookTags);
            var navigation = builder.Metadata.FindNavigation(nameof(PhoneBookRecord.PhoneBookTags));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}