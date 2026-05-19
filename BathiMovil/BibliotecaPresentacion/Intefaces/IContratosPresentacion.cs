

using BibliotecaServicios.Entidades;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IContratosPresentacion
    {
        List<Contratos> Consultar();
        Contratos Guardar(Contratos entidad);

        Contratos Modificar(Contratos entidad);

        Contratos Eliminar(Contratos entidad);
    }
}
