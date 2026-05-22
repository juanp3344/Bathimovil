

using BibliotecaServicios.Entidades;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IHistorial_PreciosPresentacion
    {
        List<Historial_Precios> Consultar();
        Historial_Precios Guardar(Historial_Precios entidad);

        Historial_Precios Modificar(Historial_Precios entidad);

        Historial_Precios Eliminar(Historial_Precios entidad);
    }
}
