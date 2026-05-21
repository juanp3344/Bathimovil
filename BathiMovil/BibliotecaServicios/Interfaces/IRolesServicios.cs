using BibliotecaServicios.Entidades;

namespace BibliotecaServicios.Interfaces
{
    public interface IRolesServicios
    {
        List<Roles> Consultar();
        Roles Guardar(Roles entidad);
        Roles Modificar(Roles entidad);
        Roles Eliminar(Roles entidad);
    }
}
