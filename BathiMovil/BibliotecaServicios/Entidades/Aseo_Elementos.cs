using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Aseo_Elementos
    {
        [Key]  public int Id_Aseo_Elemento { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public int Cantidad { get; set; }
        public string? Marca { get; set; }
        public decimal Costo { get; set; }


        // N:1
        public int Id_Tipo_Aseo_Elementos { get; set; }
        public int Id_Mantenimiento { get; set; }


        [ForeignKey("Id_Mantenimiento")] public Mantenimiento? _Mantenimiento { get; set; }
        [ForeignKey("Id_Tipo_Aseo_Elementos")] public Tipo_Aseo_Elementos? _Tipo_Aseo_Elemento { get; set; }
    }
}
