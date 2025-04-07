using _02_MVCHoca.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace _02_MVCHoca.Data
{
    public class UrunDbContext : DbContext
    {
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Bu metod sayesinde CFG'leri otomatik olarak ekletebiliyoruz
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=.;initial catalog=UrunDB;integrated security=true;trust server certificate=true");
        }
    }
}
