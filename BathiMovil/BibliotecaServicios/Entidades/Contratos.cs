
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Contratos
    {
        [Key]
        public int Id_Contrato { get; set; }
        public DateTime Fecha_Firma { get; set; }
        public string? Terminos { get; set; }
        public DateTime Fecha_Expiracion { get; set; }

        // N:1
        public int Cliente { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }

        // 1:1
        [NotMapped] public List<Prestamos>? Prestamos { get; set; }
        [NotMapped] public List<Compras>? Compras { get; set; }
        // 1:N
        [NotMapped] public List<Envios>? Envios { get; set; }

    }
}
