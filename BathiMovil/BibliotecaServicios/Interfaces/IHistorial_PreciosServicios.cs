using BibliotecaServicios.Entidades;


namespace BibliotecaServicios.Interfaces
{
    public interface IHistorial_PreciosServicios
    {
        List<Historial_Precios> Consultar();
        Historial_Precios Guardar(Historial_Precios entidad);
        Historial_Precios Modificar(Historial_Precios entidad);
        Historial_Precios Eliminar(Historial_Precios entidad);
    }
}
