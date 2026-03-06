using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoserviceMI.Detalii;

namespace AutoserviceMI.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Piesa> Piese { get; set; }
        public DbSet<Client> Clienti{ get; set; }

        public DbSet<Produs> Produse { get; set; }
        public DbSet<Vehicul> Vehicule { get; set; }

        public DbSet<Programare> Programari { get; set; }

        public DbSet<ReparatiePiesa> ReparatiePiese { get; set; }
        public DbSet<Reparatie> Reparatii { get; set; }
        public DbSet<User> Users { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=autoservice.db");
        }
    }
}
