using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Bodegas
    {
        [Key] public int Id_Bodega { get; set; }
        public string? Nombre { get; set; }
        public string? Ubicacion { get; set; }
        public int Capacidad_Maxima { get; set; }


        // N:1
        public int Sede { get; set; }
        public int Empleado { get; set; }
        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
        [ForeignKey("Sede")] public Sedes? _Sede { get; set; }

        // Relaciones 1:N
        [NotMapped] public List<Implementos>? Implementos { get; set; }
    }
}
