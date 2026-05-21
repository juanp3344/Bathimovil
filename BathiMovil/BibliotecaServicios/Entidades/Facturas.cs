
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Facturas
    {
        [Key]
        public int Id_Factura { get; set; }
        public string? Numero { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public decimal Total { get; set; }
        public decimal Impuesto_Iva { get; set; }

        // N:1
        public int Cliente { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }

        // 1:N

        [NotMapped] public List<Detalle_Facturas>? Detalle_Facturas { get; set; }
        [NotMapped] public List<Pagos>? Pagos { get; set; }

    }
}
