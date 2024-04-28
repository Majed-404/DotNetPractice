using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(x => new { x.NameAr });
            builder.Property(x => x.NameAr).IsRequired().HasMaxLength(255);

            builder.Property(x => x.NameEn).HasColumnType("VARCHAR").HasMaxLength(255).IsUnicode(false);

            builder
            .HasOne(x => x.category)
            .WithOne()
            .HasForeignKey<Category>(e => e.Id);

            builder.OwnsMany<ProductAttachment>(x => x.Attachments, attachment =>
            {
                attachment.ToTable("ProductAttachments");
                attachment.WithOwner().HasForeignKey("ProductId");
                attachment.Property(x => x.Path).IsRequired();
            });

        }
    }
}
