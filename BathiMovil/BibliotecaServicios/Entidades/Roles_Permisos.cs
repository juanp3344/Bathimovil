
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Roles_Permisos
    {
        [Key] public int Id_Rol_Permiso { get; set; }
        public bool Permitir { get; set; }
        public int Rol_Empleado { get; set; }
        public int Permiso { get; set; }
        [ForeignKey("Rol_Empleado")] public Roles_Empleados? _Id_Rol { get; set; }
        [ForeignKey("Permiso")] public Permisos? _Id_Permiso { get; set; }
    }
}
