using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BibliotecaServicios.Entidades
{
    public class Compras
    {
        [Key] public int Id_Compra { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public decimal Monto_Total { get; set; }
        public string? Metodo_Pago { get; set; }
        public int Garantia_Meses { get; set; }
        public int Contrato {  get; set; }

        [NotMapped] public List<Portatiles>? Portatiles { get; set; }
        [ForeignKey("Contrato")] public Contratos? _Id_Contrato { get; set; }

      
    }
}
