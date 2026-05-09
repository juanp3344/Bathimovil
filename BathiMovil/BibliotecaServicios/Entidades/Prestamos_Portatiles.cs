
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Prestamos_Portatiles
    {
        [Key]
        public int Id_Prestamo_Portatil { get; set; }

        // N:1
        public int Id_Prestamo { get; set; }
        public int Id_Portatil { get; set; }

        [ForeignKey("Id_Prestamo")] public Prestamos? _Prestamo { get; set; }
        [ForeignKey("Id_Portatil")] public Portatiles? _Portatil { get; set; }
    }
}
