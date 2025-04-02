using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Config
{
    public class SellerConfig : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasKey(s => s.SellerId);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Surname).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Addres).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Locality).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Province).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Phone).IsRequired();
            builder.Property(s => s.Email).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Dni).IsRequired();
        }
    }
}
