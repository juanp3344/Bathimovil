

using BibliotecaServicios.Entidades;

namespace BibliotecaPresentacion.Intefaces
{
    public interface IAuditoriasPresentacion
    {
        Auditorias Guardar(string? NC, string? operacion, string? usuario);
        List<Auditorias> Consultar();
        Task<byte[]> ExportarPdf();
    }
}
