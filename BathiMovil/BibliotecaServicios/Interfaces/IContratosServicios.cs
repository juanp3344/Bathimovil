using Biblioteca.Entidades;


namespace Biblioteca.Interfaces
{
    public interface IContratosServicios
    {
        List<Contratos> Consultar();
        Contratos Guardar(Contratos entidad);
        Contratos Modificar(Contratos entidad);
        Contratos Eliminar(Contratos entidad);
    }
}
