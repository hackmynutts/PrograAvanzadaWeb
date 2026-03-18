using Microsoft.EntityFrameworkCore;
using ProjectAgileBoard.API.Models;

namespace ProjectAgileBoard.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Story> Stories { get; set; }
        public DbSet<Models.Usuario> Usuarios{ get; set; }

        //mapping la info de la tabla porque se hace CodeFirst, se hace con Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Story>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.AssignedTo).HasMaxLength(100);
                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(25);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PokeNumber).IsRequired().HasDefaultValue(1);
            });

        }
    }
}
