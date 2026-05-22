
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Roles_Permisos
    {
        [Key] public int Id_Rol_Permiso { get; set; }
        public int Rol { get; set; }
        public int Permiso { get; set; }
        [ForeignKey("Rol")] public Roles? _Rol { get; set; }
        [ForeignKey("Permiso")] public Permisos? _Permiso { get; set; }
    }
}
