

namespace BibliotecaPresentacion.Intefaces
{
    public interface IComunicaciones
    {
        Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> EjecutarPost(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> EjecutarPut(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> EjecutarDelete(Dictionary<string, object> datos);
    }
}
