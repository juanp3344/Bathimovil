using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Prestamos
    {
        [Key]
        public int Id_Prestamo { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin_Prevista { get; set; }
        public bool Estado_Prestamo { get; set; }


        // N:1
        public int Contrato { get; set; }
        [ForeignKey("Contrato")] public Contratos? _Contrato { get; set; }


        // 1:N
        [NotMapped] public List<Mantenimiento>? Mantenimientos { get; set; }
        [NotMapped] public List<Prestamos_Portatiles>? Prestamos_Portatiles { get; set; }
    }
}
