
using BibliotecaServicios.Entidades;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IFacturasPresentacion
    {
        List<Facturas> Consultar();
        Facturas Guardar(Facturas entidad);

        Facturas Modificar(Facturas entidad);

        Facturas Eliminar(Facturas entidad);
    }
}
