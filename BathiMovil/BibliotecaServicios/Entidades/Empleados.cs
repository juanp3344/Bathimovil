using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Empleados : Personas
    {
        
        public DateTime Fecha_Ingreso { get; set; }

        // N:1
        public int Id_Rol { get; set; }
        [ForeignKey("Id_Rol")] public Roles_Empleados? _Rol { get; set; }


        // 1:N
        [NotMapped] public List<Mantenimiento>? Mantenimientos { get; set; }
        [NotMapped] public List<Envios>? Envios { get; set; }

        [NotMapped] public List<Bodegas>? Bodegas { get; set; }


    }
}
