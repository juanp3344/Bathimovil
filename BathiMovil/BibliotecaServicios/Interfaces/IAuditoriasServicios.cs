

using BibliotecaServicios.Entidades;

namespace BibliotecaServicios.Interfaces
{
    public interface IAuditoriasServicios
    {
        Auditorias Guardar(Auditorias entidad);
        List<Auditorias> Consultar();
    }
}
