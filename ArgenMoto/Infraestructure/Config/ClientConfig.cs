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
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.ClientId);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Surname).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Phone).IsRequired();
            builder.Property(c => c.Dni).IsRequired();
            builder.Property(c => c.Addres).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Locality).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Province).IsRequired().HasMaxLength(50);
        }
    }
}
