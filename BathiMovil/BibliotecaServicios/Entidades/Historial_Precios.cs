using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Historial_Precios
    {
        [Key]
        public int Id_Historial { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string? Motivo_Cambio { get; set; }

        // N:1
        public int Tipo_Portatil { get; set; }
        [ForeignKey("Tipo_Portatil")] public Tipos_Portatiles? _Tipo_Portatiles { get; set; }
    }
}
