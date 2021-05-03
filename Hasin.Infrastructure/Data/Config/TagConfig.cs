using Hasin.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hasin.Infrastructure.Data.Config
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            // builder.OwnsMany(r => r.PhoneBookTags);
            var navigation = builder.Metadata.FindNavigation(nameof(Tag.PhoneBookTags));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}