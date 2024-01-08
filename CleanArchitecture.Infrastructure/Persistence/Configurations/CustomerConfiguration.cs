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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x=> x.PhoneNumber).IsUnicode(false).HasMaxLength(10);
            builder.Property(x => x.Address).HasMaxLength(450);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(200);

            builder
                .HasMany(x=> x.Products)
                .WithOne(y=> y.Customer)
                .HasForeignKey(z=> z.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasMany(x => x.Sales)
                .WithOne(y => y.Customer)
                .HasForeignKey(z => z.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
