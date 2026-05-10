using BibliotecaServicios.Entidades;


namespace BibliotecaServicios.Interfaces
{
    public interface IComprasServicios
    {
        List<Compras> Consultar();
        Compras Guardar(Compras entidad);
        Compras Modificar(Compras entidad);
        Compras Eliminar(Compras entidad);
    }
}
