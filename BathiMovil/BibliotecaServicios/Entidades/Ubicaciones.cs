using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Ubicaciones
    {
        [Key]
        public int Id_Ubicacion { get; set; }

        public string? Ciudad { get; set; }
        public string? Direccion { get; set; }

        public int Portatil { get; set; }

        [ForeignKey("Portatil")]
        public Portatiles? _Portatil { get; set; }
    }
}
