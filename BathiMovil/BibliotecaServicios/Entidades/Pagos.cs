using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Pagos
    {
        [Key]
        public int Id_Pago { get; set; }
        public decimal Total_Pagado { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public string? Referencia_Bancaria { get; set; }
        public string? Metodo_Pago { get; set; }

        // N:1
        public int Id_Factura { get; set; }
        [ForeignKey("Id_Factura")] public Facturas? _Factura { get; set; }
    }
}
