using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Infraestructure.Config
{
    public class SaleMotoConfig : IEntityTypeConfiguration<SaleMoto>
    {
        public void Configure(EntityTypeBuilder<SaleMoto> builder)
        {
            builder.HasKey(s => s.ShoppingCartId);
            builder.Property(s => s.Quantity).IsRequired();
            builder.Property(s => s.Price).IsRequired();
            builder.Property(s => s.Discount);

        }
    }
}
