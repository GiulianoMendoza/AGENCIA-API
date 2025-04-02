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
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.SaleId);
            builder.Property(s => s.TotalPay).IsRequired();
            builder.Property(s => s.Subtotal).IsRequired();
            builder.Property(s => s.TotalDiscount).IsRequired();
            builder.Property(s => s.Taxes).IsRequired();
            builder.Property(s => s.Date).IsRequired();

            // Configuración de relaciones
            builder.HasMany(s => s.SaleMotos)
                   .WithOne(sm => sm.Venta)
                   .HasForeignKey(sm => sm.Sale);
        }
    }
}
