using BibliotecaServicios.Entidades;


namespace BibliotecaServicios.Interfaces
{
    public interface IFacturasServicios
    {
        List<Facturas> Consultar();
        Facturas Guardar(Facturas entidad);
        Facturas Modificar(Facturas entidad);
        Facturas Eliminar(Facturas entidad);
    }
}
