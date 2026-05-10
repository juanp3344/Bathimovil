using BibliotecaServicios.Entidades;


namespace BibliotecaServicios.Interfaces
{
    public interface IDetalle_FacturasServicios
    {
        List<Detalle_Facturas> Consultar();
        Detalle_Facturas Guardar(Detalle_Facturas entidad);
        Detalle_Facturas Modificar(Detalle_Facturas entidad);
        Detalle_Facturas Eliminar(Detalle_Facturas entidad);
    }
}
