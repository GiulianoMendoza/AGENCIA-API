using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Infraestructure.Data
{
    public class ClientData : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(
                new Client { ClientId = Guid.NewGuid(), Name = "Giuliano", Surname = "Mendoza", Email = "Giuliano@gmail.com",Dni= 41539440, Phone = 1141462757, Addres = "MZA30", Locality = "CLAYPOLE", Province= "BS AS" });
        }
    }
}
