

using BibliotecaServicios.Entidades;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IMantenimientosPresentacion
    {
        List<Mantenimientos> Consultar();
        Mantenimientos Guardar(Mantenimientos entidad);

        Mantenimientos Modificar(Mantenimientos entidad);

        Mantenimientos Eliminar(Mantenimientos entidad);
        Task<byte[]> ExportarPdf();
    }
}
