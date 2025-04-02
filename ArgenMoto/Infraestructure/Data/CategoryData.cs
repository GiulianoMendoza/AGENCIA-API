using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class CategoryData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CategoryId = 1, Name = "CUBS" },
                new Category { CategoryId = 2, Name = "SCOOTERS" },
                new Category { CategoryId = 3, Name = "CALLE" },
                new Category { CategoryId = 4, Name = "ENDURO" },
                new Category { CategoryId = 5, Name = "TOURING" },
                new Category { CategoryId = 6, Name = "NAKED" },
                new Category { CategoryId = 7, Name = "RETRO" },
                new Category { CategoryId = 8, Name = "DEPORTIVAS" }
                );
        }
    }
}
