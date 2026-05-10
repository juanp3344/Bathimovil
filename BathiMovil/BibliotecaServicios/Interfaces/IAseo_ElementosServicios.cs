using BibliotecaServicios.Entidades;


namespace BibliotecaServicios.Interfaces
{
    public interface IAseo_ElementosServicios
    {
        List<Aseo_Elementos> Consultar();
        Aseo_Elementos Guardar(Aseo_Elementos entidad);
        Aseo_Elementos Modificar(Aseo_Elementos entidad);
        Aseo_Elementos Eliminar(Aseo_Elementos entidad);
    }
}
