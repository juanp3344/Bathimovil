
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Roles_Permisos
    {
        [Key] public int Id_Rol_Permiso { get; set; }
        public bool Permitir { get; set; }
        public int Id_Rol{ get; set; }
        public int Id_Permiso { get; set; }
        [ForeignKey("Id_Rol")] public Roles_Empleados? _Id_Rol { get; set; }
        [ForeignKey("Id_Permiso")] public Permisos? _Id_Permiso { get; set; }
    }
}
