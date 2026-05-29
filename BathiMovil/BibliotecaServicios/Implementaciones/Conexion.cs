

using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaServicios.Implementaciones
{
    public class Conexion: DbContext, IConexion
    {

        public string? string_conexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(string_conexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TPT
            modelBuilder.Entity<Personas>().ToTable("Personas");

            modelBuilder.Entity<Empleados>().ToTable("Empleados");

            modelBuilder.Entity<Clientes>().ToTable("Clientes");

            modelBuilder.Entity<Personas>().Property(p => p.Id_Persona).ValueGeneratedOnAdd();
        }

        public DbSet<Aseo_Elementos>? Aseo_Elementos { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }
        public DbSet<Bodegas>? Bodegas { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Compras>? Compras { get; set; }
        public DbSet<Contratos>? Contratos { get; set; }
        public DbSet<Detalle_Facturas>? Detalle_Facturas { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Envios>? Envios { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Historial_Precios>? Historial_Precios { get; set; }
        public DbSet<Implementos>? Implementos { get; set; }
        public DbSet<Mantenimientos>? Mantenimientos { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Personas>? Personas { get; set; }
        public DbSet<Portatiles>? Portatiles { get; set; }
        public DbSet<Prestamos>? Prestamos { get; set; }
        public DbSet<Permisos>? Permisos { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Sedes>? Sedes { get; set; }
        public DbSet<Tipo_Aseo_Elementos>? Tipo_Aseo_Elementos { get; set; }

        public DbSet<Tipos_Implementos>? Tipos_Implementos { get; set; }
        public DbSet<Tipos_Intermedia>? Tipos_Intermedia { get; set; }
        public DbSet<Tipos_Portatiles>? Tipos_Portatiles { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Ubicaciones>? Ubicaciones { get; set; }
    }
}
