

using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;

namespace BibliotecaPresentacion.Implementaciones
{
    public class ImplementosPresentacion: IImplementosPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Implementos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Implementos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Implementos>();

            return JsonConvert.DeserializeObject<List<Implementos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Implementos Guardar(Implementos entidad)
        {
            if (entidad.Id_Implemento != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Implementos/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Implementos();

            return JsonConvert.DeserializeObject<Implementos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Implementos Modificar(Implementos entidad)
        {
            if (entidad.Id_Implemento == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Implementos/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Implementos();

            return JsonConvert.DeserializeObject<Implementos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Implementos Eliminar(Implementos entidad)
        {
            if (entidad.Id_Implemento == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Implementos/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Implementos();

            return JsonConvert.DeserializeObject<Implementos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
