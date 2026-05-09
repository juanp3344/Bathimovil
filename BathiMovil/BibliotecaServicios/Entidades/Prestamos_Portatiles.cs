
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Prestamos_Portatiles
    {
        [Key]
        public int Id_Prestamo_Portatil { get; set; }

        // N:1
        public int Prestamo { get; set; }
        public int Portatil { get; set; }

        [ForeignKey("Prestamo")] public Prestamos? _Prestamo { get; set; }
        [ForeignKey("Portatil")] public Portatiles? _Portatil { get; set; }
    }
}
