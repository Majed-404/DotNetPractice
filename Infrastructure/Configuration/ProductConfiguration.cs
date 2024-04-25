using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(x => new { x.Name });

            builder.OwnsMany<ProductAttachment>(x => x.Attachments, attachment =>
            {
                attachment.ToTable("ProductAttachments");
                attachment.WithOwner().HasForeignKey("ProductId");
                attachment.Property(x => x.Path).IsRequired();
            });
        }
    }
}
