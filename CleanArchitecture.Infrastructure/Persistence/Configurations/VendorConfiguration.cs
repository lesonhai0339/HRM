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
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder
                .HasMany(x => x.Sales)
                .WithOne(y => y.Vendor)
                .HasForeignKey(z => z.VendorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
