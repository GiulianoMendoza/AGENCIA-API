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
    public class BuyConfig : IEntityTypeConfiguration<Buy>
    {
        public void Configure(EntityTypeBuilder<Buy> builder)
        {
            builder.HasKey(b => b.OrderbuyId);
            builder.Property(b => b.Quantity).IsRequired();
            builder.Property(b => b.TotalPay).IsRequired();
            builder.Property(b => b.Subtotal).IsRequired();
            builder.Property(b => b.Taxes).IsRequired();
            builder.Property(b => b.Description).HasMaxLength(100);
            builder.Property(b => b.DateStar).IsRequired();
            builder.Property(b => b.DateEnd).IsRequired();
        }
    }
}
