
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Personas
    {
        [Key]
        public int Id_Persona { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }

        [NotMapped] public List<Usuarios>? Usuarios { get; set; }
    }
}
