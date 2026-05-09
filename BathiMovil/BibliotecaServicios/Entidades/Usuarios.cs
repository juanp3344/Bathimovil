
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Usuarios
    {
        [Key]
        public int Id_Usuario { get; set; }
        public string? Username { get; set; }
        public string? Password_Hash { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha_Ultimo_Acceso { get; set; }

        

        public int Id_persona { get; set; }
        [ForeignKey("Id_persona")] public Personas? _Persona { get; set; }
    }
}
