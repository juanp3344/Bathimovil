
using BibliotecaServicios.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BibliotecaServicios.Interfaces
{
    public interface IConexion
    {
        public string? string_conexion { get; set; }
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
        public DbSet<Mantenimiento>? Mantenimiento { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Personas>? Personas { get; set; }
        public DbSet<Portatiles>? Portatiles { get; set; }
        public DbSet<Prestamos>? Prestamos { get; set; }
        public DbSet<Prestamos_Portatiles>? Prestamos_Portatiles { get; set; }
        public DbSet<Roles_Empleados>? Roles_Empleados { get; set; }
        public DbSet<Sedes>? Sedes { get; set; }
        public DbSet<Tipo_Aseo_Elementos>? Tipo_Aseo_Elementos { get; set; }
        public DbSet<Tipo_Implementos>? Tipo_Implementos { get; set; }
        public DbSet<Tipos_Intermedia>? Tipos_Intermedia { get; set; }
        public DbSet<Tipos_Portatiles>? Tipos_Portatiles { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        DatabaseFacade Database { get; }
    }

}
