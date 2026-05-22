using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Implementos
    {
        [Key]
        public int Id_Implemento { get; set; }
        public int Vida_Util { get; set; }
        public string? Estado { get; set; }
        public DateTime fecha_fabricacion { get; set; }
        public string? Marca { get; set; }
        public decimal Costo { get; set; }

        // N:1
        public int Portatil { get; set; }
        public int Bodega { get; set; }
        public int Tipo_Implemento { get; set; }

        [ForeignKey("Tipo_Implemento")] public Tipos_Implementos? _Tipo_Implemento { get; set; }
        [ForeignKey("Portatil")] public Portatiles? _Portatil { get; set; }
        [ForeignKey("Bodega")] public Bodegas? _Bodega { get; set; }

    }
}
