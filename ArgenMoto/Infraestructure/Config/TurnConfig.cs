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
    public class TurnConfig : IEntityTypeConfiguration<Turn>
    {
        public void Configure(EntityTypeBuilder<Turn> builder)
        {
            builder.HasKey(t => t.TurnId);
            builder.Property(t => t.Date).IsRequired();
            builder.Property(t => t.TypeService).IsRequired();
            builder.HasOne(s => s.techn)
                .WithMany(v => v.Turns)
                .HasForeignKey(s => s.TechnId);

            builder.HasOne(s => s.client)
                .WithMany()
                .HasForeignKey(s => s.ClientId);

            builder.HasOne(s => s.Moto)
                .WithMany()
                .HasForeignKey(s => s.Motoid);
            builder.HasOne(s => s.sale)
               .WithMany()
               .HasForeignKey(s => s.SaleId);

        }
    }
}
