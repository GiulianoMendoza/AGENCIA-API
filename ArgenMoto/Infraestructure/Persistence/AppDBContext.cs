using Domain.Entities;
using Infraestructure.Config;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence
{
    public class AppDBContext : DbContext
    {
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleMoto> SaleMoto { get; set; }
        public DbSet<Moto> Moto { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Techn> Techns { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Buy> buys { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new SaleConfig());
            modelBuilder.ApplyConfiguration(new SaleMotoConfig());
            modelBuilder.ApplyConfiguration(new MotoConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new SellerConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new BuyConfig());
            modelBuilder.ApplyConfiguration(new DealerConfig());
            modelBuilder.ApplyConfiguration(new TechnConfig());
            modelBuilder.ApplyConfiguration(new TurnConfig());
            modelBuilder.ApplyConfiguration(new CategoryData());
            modelBuilder.ApplyConfiguration(new MotoData());
            modelBuilder.ApplyConfiguration(new ClientData());
        }     
        
    }
}
