using Hasin.Core.Entities.PhoneBookRecordAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hasin.Infrastructure.Data.Config
{
    public class PhoneBookRecordConfig : IEntityTypeConfiguration<PhoneBookRecord>
    {
        public void Configure(EntityTypeBuilder<PhoneBookRecord> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(PhoneBookRecord.Tags));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}