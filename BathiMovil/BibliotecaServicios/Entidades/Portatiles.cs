using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Portatiles
    {
        [Key]
        public int Id_Portatil { get; set; }
        public string? Numero_Serial { get; set; }
        public DateTime Fecha_Fabricacion { get; set; }
        public string? Estado_Actual { get; set; }



        // N:1
        public int Tipo_Portatil { get; set; }
        public int Sede { get; set; }
        public int? Compra { get; set; }


        [ForeignKey("Tipo_Portatil")] public Tipos_Portatiles? _Tipo_Portatil { get; set; }
        [ForeignKey("Sede")] public Sedes? _Sede { get; set; }
        [ForeignKey("Compra")] public Compras? _Compra { get; set; }
   
        [NotMapped] public List<Ubicaciones>? Ubicaciones { get; set;  }
        [NotMapped] public List<Prestamos>? Prestamos { get; set; }
    }
}
