

using BibliotecaServicios.Entidades;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IEmpleadosPresentacion
    {
        List<Empleados> Consultar();
        Empleados Guardar(Empleados entidad);

        Empleados Modificar(Empleados entidad);

        Empleados Eliminar(Empleados entidad);
        Task<byte[]> ExportarPdf();
    }
}
