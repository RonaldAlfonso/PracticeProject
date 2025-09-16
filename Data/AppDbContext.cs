
using Microsoft.EntityFrameworkCore;
using MiApi.Models;

namespace MiApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Aquí defines tus tablas como DbSet
        public DbSet<Mandril> Mandriles { get; set; }
        public DbSet<Habilidad> Habilidades { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mandril>().HasMany(m => m.Habilidades).
            WithMany(n => n.mandriles).
            UsingEntity(j => j.ToTable("MandrilHabilidad;"));
        }
    }

}
