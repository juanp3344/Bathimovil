using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Tipos_Portatiles
    {
        [Key]
        public int Id_Tipo_Portatil { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio_Actual { get; set; }
        public string? ImagenUrl { get; set; }
        public decimal Altura { get; set; }
        public decimal Ancho { get; set; }
        public decimal Largo { get; set; }

        // 1:N
        [NotMapped] public List<Portatiles>? Portatiles { get; set; }
        [NotMapped] public List<Historial_Precios>? Historial_Precios { get; set; }
        [NotMapped] public List<Tipos_Intermedia>? Tipos_Intermedias { get; set; }
    }
}
