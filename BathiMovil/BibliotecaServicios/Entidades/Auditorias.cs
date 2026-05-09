

using System.ComponentModel.DataAnnotations;

namespace BibliotecaServicios.Entidades
{
    public class Auditorias
    {
        [Key] public int Id_Auditoria { get; set; }
        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }
        public string? Nombre_Ejecutor { get; set; }
    }
}
