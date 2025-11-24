using Microsoft.EntityFrameworkCore;
using MiVeterinaria.Models;
namespace MiVeterinaria.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
        
        }
        public DbSet<Mascota> Mascotas { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Mascota>(tb =>
            {
                tb.HasKey(col => col.IdMascota);

                tb.Property(col => col.IdMascota)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.NombreMascota).HasMaxLength(50);
                tb.Property(col => col.NombrePropietario).HasMaxLength(50);
                tb.Property(col => col.Correo).HasMaxLength(50);

            });
            modelBuilder.Entity<Mascota>().ToTable(("Mascota"));
        }

    }
}
