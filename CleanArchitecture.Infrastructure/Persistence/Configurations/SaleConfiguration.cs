using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Sumtotal).IsRequired();

            builder
                .HasOne(x => x.Customer)
                .WithMany(y => y.Sales)
                .HasForeignKey(z => z.CustomerId);
            builder
                .HasOne(x => x.Vendor)
                .WithMany(y => y.Sales)
                .HasForeignKey(z => z.VendorId);
            builder
                .HasOne(x => x.Shop)
                .WithMany(y => y.Sales)
                .HasForeignKey(z => z.ShopId);
            builder
                .HasOne(x => x.Product)
                .WithMany(y => y.Sales)
                .HasForeignKey(z => z.ProductId);
        }
    }
}
