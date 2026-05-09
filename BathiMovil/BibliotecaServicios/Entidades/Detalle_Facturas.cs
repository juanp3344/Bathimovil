using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BibliotecaServicios.Entidades
{
    public class Detalle_Facturas
    {
        [Key]
        public int Id_Detalle { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo_Unitario { get; set; }
        public decimal Descuento_Aplicado { get; set; }
        public decimal Subtotal { get; set; }

        // N:1
        public int Factura { get; set; }
        [ForeignKey("Factura")] public Facturas? _Factura { get; set; }
    }
}
