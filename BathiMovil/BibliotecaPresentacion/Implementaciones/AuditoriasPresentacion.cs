

using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;

namespace BibliotecaPresentacion.Implementaciones
{
    public class AuditoriasPresentacion: IAuditoriasPresentacion
    {
        private IComunicaciones? iComunicaciones;
        public Auditorias Guardar(string? NC, string? operacion, string? usuario)
        {

            var entidad = new Auditorias()
            {
                HoraAccion = DateTime.Now.ToString("HH:mm:ss"),
                Nivel_Cambio = NC,
                Operacion = operacion,
                Nombre = usuario

            };

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Auditorias/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Auditorias();

            return JsonConvert.DeserializeObject<Auditorias>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
