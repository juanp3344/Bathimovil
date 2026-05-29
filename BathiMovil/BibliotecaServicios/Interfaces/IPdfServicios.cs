

namespace BibliotecaServicios.Interfaces
{
    public interface IPdfServicios
    {
        byte[] GenerarPdf<T>(List<T> datos, string titulo);
    }
}
