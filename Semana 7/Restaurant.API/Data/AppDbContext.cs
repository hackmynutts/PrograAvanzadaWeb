using Microsoft.EntityFrameworkCore;
using Restaurant.API.Models;

namespace Restaurant.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }

        //mapping la info de la tabla porque se hace CodeFirst, se hace con Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
                modelBuilder.Entity<Order>(entity =>
                {
                    entity.HasKey(e => e.ID);// clave primaria
                    entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(100);// es requerido y maximo 100 caracteres
                    entity.Property(e => e.Dish).IsRequired();
                });
        }
    }
}
