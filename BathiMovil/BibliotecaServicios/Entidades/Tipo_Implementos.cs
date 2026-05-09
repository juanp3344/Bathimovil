
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Tipo_Implementos
    {
        [Key]
        public int Id_Tipo_Implemento { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Ancho { get; set; }
        public decimal Largo { get; set; }
        public decimal Alto { get; set; }
        [NotMapped] public List<Implementos>? Implementos { get; set; }
        [NotMapped] public List<Tipos_Intermedia>? Tipos_Intermedias { get; set; }
    }
}
