using _02_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_MVC.Data
{
    public class UrunDbContext : DbContext
    {
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
    }
}
