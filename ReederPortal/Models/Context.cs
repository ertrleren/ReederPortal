using Microsoft.EntityFrameworkCore;

namespace ReederPortal.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<Birim> Birims { get; set; }
        public DbSet<Personel> Personels { get; set; }

        public DbSet<Unvan> Unvans { get; set; }
        public DbSet<Seviye> Seviyes { get; set; }

        
        
    }
}
