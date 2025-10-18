using Microsoft.EntityFrameworkCore;

namespace FitTrackAPI.Models
{
    public class FitTrackContext : DbContext
    {
        
        public FitTrackContext(DbContextOptions<FitTrackContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<Progreso> Progresos { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Rutina>().HasKey(r => r.Id);
            modelBuilder.Entity<Ejercicio>().HasKey(e => e.Id);
            modelBuilder.Entity<Progreso>().HasKey(p => p.Id);
        }
    }
}
