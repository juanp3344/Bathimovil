

using BibliotecaServicios.Entidades;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IEnviosPresentacion
    {
        List<Envios> Consultar();
        Envios Guardar(Envios entidad);

        Envios Modificar(Envios entidad);

        Envios Eliminar(Envios entidad);
    }
}
