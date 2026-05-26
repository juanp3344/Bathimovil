using BibliotecaServicios.Entidades;

namespace BibliotecaServicios.Interfaces
{
    public interface IUbicacionesServicios
    {
        List<Ubicaciones> Consultar();
        Ubicaciones Guardar(Ubicaciones entidad);
        Ubicaciones Modificar(Ubicaciones entidad);
        Ubicaciones Eliminar(Ubicaciones entidad);
    }
}