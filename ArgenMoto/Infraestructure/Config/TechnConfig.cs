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
    public class TechnConfig : IEntityTypeConfiguration<Techn>
    {
        public void Configure(EntityTypeBuilder<Techn> builder)
        {
            builder.HasKey(t => t.TecnicoId);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Surname).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Dni).IsRequired();
            builder.Property(t => t.Email).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Addres).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Locality).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Province).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Phone).IsRequired();
        }
    }
}
