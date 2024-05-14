using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(n => n.NameAr);
            builder.Property(n => n.NameAr).HasMaxLength(150).IsRequired();

            builder.Property(n => n.NameEn).HasColumnType("VARCHAR").HasMaxLength(150).IsUnicode(false).IsRequired(false);

        }

    }
}
