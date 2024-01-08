using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(y => y.Products)
                .HasForeignKey(z => z.CustomerId);
            builder.HasOne(x => x.Shop)
                .WithMany(y => y.Products)
                .HasForeignKey(z => z.ShopId);
            builder
                .HasMany(x => x.Sales)
                .WithOne(y => y.Product)
                .HasForeignKey(z => z.ProductId)
                .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}
