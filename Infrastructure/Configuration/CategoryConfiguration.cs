using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.HasIndex(x => x.NameAr);
            //builder.Property(x => x.NameAr).HasColumnType("NVARCHAR").HasMaxLength(255).IsRequired();

            //builder.HasIndex(x => x.NameEn);
            //builder.Property(x => x.NameEn).HasColumnType("VARCHAR").HasMaxLength(255).IsUnicode(false).IsRequired(false);


            builder.HasIndex(n => n.NameAr);
            builder.Property(n => n.NameAr).HasMaxLength(150).IsRequired();

            builder.Property(n => n.NameEn).HasColumnType("VARCHAR").HasMaxLength(150).IsUnicode(false).IsRequired(false);

        }

    }
}
