using BibliotecaServicios.Entidades;


namespace BibliotecaServicios.Interfaces
{
    public interface IContratosServicios
    {
        List<Contratos> Consultar();
        Contratos Guardar(Contratos entidad);
        Contratos Modificar(Contratos entidad);
        Contratos Eliminar(Contratos entidad);
    }
}
