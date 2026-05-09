
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Mantenimiento
    {
        [Key]
        public int Id_Mantenimiento { get; set; }
        public DateTime Fecha_Servicio { get; set; }
        public string? Tipo_Mantenimiento { get; set; }
        public string? Descripcion_Trabajo { get; set; }
        public decimal Costo_Mano_Obra { get; set; }

        // N:1
        public int Id_Prestamo { get; set; }
        public int Id_Empleado { get; set; }
        public int Id_Portatil { get; set; }

        [ForeignKey("Id_Prestamo")] public Prestamos? _Prestamo { get; set; }
        [ForeignKey("Id_Empleado")] public Empleados? _Empleado { get; set; }
        [ForeignKey("Id_Portatil")] public Portatiles? _Portatil { get; set; }

        // 1:N
        [NotMapped] public List<Aseo_Elementos>? Aseo_Elementos { get; set; }

    }
}
