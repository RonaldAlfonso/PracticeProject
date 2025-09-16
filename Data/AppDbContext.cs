
using MiApi.Models;
using Microsoft.EntityFrameworkCore;
//using Model;

namespace MiApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Aquí defines tus tablas como DbSet
        public DbSet<Mandril> Mandrils { get; set; }
    }

   
}
