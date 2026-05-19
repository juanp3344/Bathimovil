
using BibliotecaServicios.Entidades;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IImplementosPresentacion
    {
        List<Implementos> Consultar();
        Implementos Guardar(Implementos entidad);

        Implementos Modificar(Implementos entidad);

        Implementos Eliminar(Implementos entidad);
    }
}
