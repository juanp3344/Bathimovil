

using System.ComponentModel.DataAnnotations;

namespace BibliotecaServicios.Entidades
{
    public class Auditorias
    {
        [Key] public int Id { get; set; }
        public string? HoraAccion { get; set; }
        public string? Nivel_Cambio { get; set; }
        public string? Nombre { get; set; }
        public string? Operacion { get; set; }
    }
}
