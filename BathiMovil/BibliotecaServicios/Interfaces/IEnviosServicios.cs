using Biblioteca.Entidades;


namespace Biblioteca.Interfaces
{
    public interface IEnviosServicios
    {
        List<Envios> Consultar();
        Envios Guardar(Envios entidad);
        Envios Modificar(Envios entidad);
        Envios Eliminar(Envios entidad);
    }
}
