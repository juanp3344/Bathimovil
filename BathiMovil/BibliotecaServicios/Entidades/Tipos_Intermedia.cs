using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Tipos_Intermedia
    {
        [Key]
        public int Id_Tipos_Intermedia { get; set; }
        public string? Posicion_Montaje { get; set; }

        // N:1
        public int Id_Tipo_Implemento { get; set; }
        public int Id_Tipo_Portatil { get; set; }
        [ForeignKey("Id_Tipo_Portatil")] public Tipos_Portatiles? _Tipo_Portatil { get; set; }
        [ForeignKey("Id_Tipo_Implemento")] public Tipo_Implementos? _Tipo_Implemento { get; set; }
    }
}
