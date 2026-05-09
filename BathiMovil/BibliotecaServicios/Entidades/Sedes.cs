using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Sedes
    {
        [Key]
        public int Id_Sede { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Telefono_Contacto { get; set; }

        // 1:N
        [NotMapped] public List<Portatiles>? Portatiles { get; set; }
        [NotMapped] public List<Bodegas>? Bodegas { get; set; }
    }
}
