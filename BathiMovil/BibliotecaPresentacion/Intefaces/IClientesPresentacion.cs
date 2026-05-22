

using BibliotecaServicios.Entidades;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IClientesPresentacion
    {
        List<Clientes> Consultar();
        Clientes Guardar(Clientes entidad);

        Clientes Modificar(Clientes entidad);

        Clientes Eliminar(Clientes entidad);
    }
}
