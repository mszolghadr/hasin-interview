using Hasin.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hasin.Infrastructure.Data.Config
{
    public class PhoneBookTagConfig : IEntityTypeConfiguration<PhoneBookTag>
    {
        public void Configure(EntityTypeBuilder<PhoneBookTag> builder)
        {
            builder.HasOne(r => r.PhoneBookRecord).WithMany(p => p.PhoneBookTags);
            builder.HasOne(r => r.Tag).WithMany(t => t.PhoneBookTags);
            builder.HasKey(k => new { k.PhoneBookRecordId, k.TagId });
        }
    }
}