using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Empleados : Personas
    {
        
        public DateTime Fecha_Ingreso { get; set; }

        public decimal? Salario_Base { get; set; }

        


        // 1:N
        [NotMapped] public List<Mantenimientos>? Mantenimientos { get; set; }
        [NotMapped] public List<Envios>? Envios { get; set; }

        [NotMapped] public List<Bodegas>? Bodegas { get; set; }


    }
}
