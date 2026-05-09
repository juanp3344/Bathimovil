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
        public int Id_Tipo_Portatil { get; set; }
        public int Id_Sede { get; set; }
        public int Id_Compra { get; set; }


        [ForeignKey("Id_Tipo_Portatil")] public Tipos_Portatiles? _Tipo_Portatil { get; set; }
        [ForeignKey("Id_Sede")] public Sedes? _Sede { get; set; }
        [ForeignKey("Id_Compra")] public Compras? _Compra { get; set; }
    }
}
