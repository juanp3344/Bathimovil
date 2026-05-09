
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Tipo_Aseo_Elementos
    {
        [Key]
        public int Id_Tipo_Aseo_Elemento { get; set; }
        public string? Uso { get; set; }
        public string? Instrucciones_Uso { get; set; }
        public decimal Medida_litros { get; set; }
        public string? Toxicidad { get; set; }

        [NotMapped] public List<Aseo_Elementos>? Aseo_Elementos { get; set; }
    }
}
