using BibliotecaServicios.Entidades;


namespace BibliotecaServicios.Interfaces
{
    public interface IEnviosServicios
    {
        List<Envios> Consultar();
        Envios Guardar(Envios entidad);
        Envios Modificar(Envios entidad);
        Envios Eliminar(Envios entidad);
    }
}
