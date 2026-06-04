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
        public int Portatil {  get; set; }
        public int Contrato { get; set; }
        [ForeignKey("Contrato")] public Contratos? _Contrato { get; set; }
        [ForeignKey("Portatil")]public Portatiles? _Portatil { get; set; } = null;
        // 1:N
        [NotMapped] public List<Mantenimientos>? Mantenimientos { get; set; }
    }
}
