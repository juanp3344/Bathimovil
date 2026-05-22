
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Permisos
    {
        [Key] public int Id_Permiso { get; set; }
        public string? Nombre_Permiso { get; set; }

        public int Rol { get; set; }

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }
    }
}
