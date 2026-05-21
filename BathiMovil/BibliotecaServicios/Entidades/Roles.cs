using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Roles
    {
        public enum Niveles_Acceso
        {
            superadmin = 1,
            Gerencial = 2,
            Supervisor = 3,
            Invitado = 4
        }
        [Key]
        public int Id_Rol { get; set; }
        public string? Nombre_Rol { get; set; }
        public string? Descripcion_Rol { get; set; }
        public decimal? Salario_Empleado { get; set; }
        // public Niveles_Acceso Permisos { get; set; }

        // 1:N
        [NotMapped] public List<Usuarios>? Usuarios { get; set; }
        [NotMapped] public List<Roles_Permisos>? Roles_Permisos { get; set; }
    }
}
