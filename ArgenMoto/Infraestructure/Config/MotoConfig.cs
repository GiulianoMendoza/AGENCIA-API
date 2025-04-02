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
    public class MotoConfig : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.HasKey(x => x.MotoId);
            builder.Property(x => x.MotoName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.StockMin).IsRequired();
            builder.Property(x => x.StockMax).IsRequired();
            builder.Property(x => x.StockCurrent).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(x => x.Mark).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Model).HasMaxLength(50).IsRequired();
            builder.Property(x => x.EngineNum).IsRequired();
            builder.Property(x => x.ChasisNum).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Cylinder).IsRequired();
            builder.Property(x => x.imageUrl);
            builder.Property(x => x.Discount);
            builder.HasOne(p => p.Category).WithMany(c => c.Motos).HasForeignKey(p => p.CategoryId).IsRequired();
            builder.HasMany<SaleMoto>(p => p.SaleMotos).WithOne(sp => sp.Moto).HasForeignKey(sp => sp.Mot).IsRequired();
        }
    }
}
