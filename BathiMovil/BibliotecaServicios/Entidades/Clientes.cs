using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaServicios.Entidades
{
    public class Clientes : Personas
    {
        public enum CategoriaCliente
        {
            Constructora = 1,
            OrganizadorEventos = 2,
            EntidadPublica = 3,
            Industrial = 4,
            Particular = 5
        }
        public string? Razon_Social { get; set; }
        public string? Nit_CC { get; set; }
        public string? Direccion_Fiscal { get; set; }
       // public CategoriaCliente Tipo_Cliente { get; set; }

        // 1:N
        [NotMapped] public List<Contratos>? Contratos { get; set; }
        [NotMapped] public List<Facturas>? Facturas { get; set; }

    }
}
