using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;

namespace BibliotecaPresentacion.Implementaciones
{
    public class EnviosPresentacion: IEnviosPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Envios> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Envios/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Envios>();

            return JsonConvert.DeserializeObject<List<Envios>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Envios Guardar(Envios entidad)
        {
            if (entidad.Id_Envio != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Envios/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Envios();

            return JsonConvert.DeserializeObject<Envios>(
                respuesta["Valor"].ToString()!)!;
        }

        public Envios Modificar(Envios entidad)
        {
            if (entidad.Id_Envio == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Envios/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Envios();

            return JsonConvert.DeserializeObject<Envios>(
                respuesta["Valor"].ToString()!)!;
        }

        public Envios Eliminar(Envios entidad)
        {
            if (entidad.Id_Envio == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Envios/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Envios();

            return JsonConvert.DeserializeObject<Envios>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
