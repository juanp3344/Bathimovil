using BibliotecaServicios.Entidades;


namespace BibliotecaServicios.Interfaces
{
    public interface IEmpleadosServicios
    {
        List<Empleados> Consultar();
        Empleados Guardar(Empleados entidad);
        Empleados Modificar(Empleados entidad);
        Empleados Eliminar(Empleados entidad);
    }
}
