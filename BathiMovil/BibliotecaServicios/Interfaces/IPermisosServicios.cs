using BibliotecaServicios.Entidades;

namespace BibliotecaServicios.Interfaces
{
    public interface IPermisosServicios
    {
        List<Permisos> Consultar();
        Permisos Guardar(Permisos entidad);
        Permisos Modificar(Permisos entidad);
        Permisos Eliminar(Permisos entidad);
        Permisos ComprobarPermiso(Permisos entidad);
    }
}
