using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Collections.Generic;
using EticaretWebSitesi.Models.Siniflar;

namespace EticaretWebSitesi.Models.Siniflar
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Admin> admins { get; set; }
        public DbSet<Musteri> musteris { get; set; }
        public DbSet<Fatura> faturalars { get; set; }
        public DbSet<FaturaIci> faturaIcis { get; set; }
        public DbSet<Kategori> kategoris { get; set; }
        public DbSet<SatisHareket> satisHarekets { get; set; }
        public DbSet<Urun> uruns { get; set; }

        public DbSet<Favori> favoris { get; set; }
    }
}






