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
    public class DealerConfig : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasKey(d => d.dealerID);
            builder.Property(d => d.Cuit).IsRequired();
            builder.Property(d => d.ReasonSocial).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Surname).IsRequired().HasMaxLength(50);
            builder.Property(d => d.NameProv).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Addres).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Locality).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Province).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Phone).IsRequired();
            builder.Property(d => d.Email).IsRequired().HasMaxLength(100);
        }
    }
}
