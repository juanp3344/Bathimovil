using BibliotecaServicios.Entidades;


namespace BibliotecaServicios.Interfaces
{
    public interface IBodegasServicios
    {
        List<Bodegas> Consultar();
        Bodegas Guardar(Bodegas entidad);
        Bodegas Modificar(Bodegas entidad);
        Bodegas Eliminar(Bodegas entidad);
    }
}
