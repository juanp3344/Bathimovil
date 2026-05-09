using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Envios
    {
        [Key] public int Id_Envio { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public string? Destino { get; set; }
        public decimal Costo_Envio { get; set; }
        public DateTime Fecha_Entrega_Estimada { get; set; }

        // N:1
        public int Id_Contrato { get; set; }
        public int Id_Empleado { get; set; }

        [ForeignKey("Id_Contrato")] public Contratos? _Contrato { get; set; }
        [ForeignKey("Id_Empleado")] public Empleados? _Empleado { get; set; }
       
    }
}
