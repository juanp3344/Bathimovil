using Biblioteca.Entidades;


namespace Biblioteca.Interfaces
{
    public interface IClientesServicios
    {
        List<Clientes> Consultar();
        Clientes Guardar(Clientes entidad);
        Clientes Modificar(Clientes entidad);
        Clientes Eliminar(Clientes entidad);
    }
}
