using BootcampCLT.Infraestructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace BootcampCLT.Infraestructure.Context
{
    public class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

        public DbSet<Producto> Productos => Set<Producto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>(b =>
            {
                b.ToTable("productos");
                b.HasKey("Id");
                b.Property(p => p.Id).HasColumnName("id");
                b.Property(p => p.Codigo).HasColumnName("codigo").HasMaxLength(50).IsRequired();
                b.Property(p => p.Nombre).HasColumnName("nombre").HasMaxLength(150).IsRequired();
                b.Property(p => p.Descripcion).HasColumnName("descripcion");
                b.Property(p => p.Precio).HasColumnName("precio").HasColumnType("decimal(50,2)");
                b.Property(p => p.Activo).HasColumnName("activo").HasDefaultValue(true);
                b.Property(p => p.CategoriaId).HasColumnName("categoria_id");
                b.Property(p => p.FechaCreacion).HasColumnName("fecha_creacion").HasDefaultValueSql("NOW()");
                b.Property(p => p.FechaActualizacion).HasColumnName("fecha_actualizacion");
                b.Property(p => p.CantidadStock).HasColumnName("cantidad_stock").HasDefaultValue(0);
                
            });
        }
    }
}
