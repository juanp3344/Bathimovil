

using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;

namespace BibliotecaPresentacion.Implementaciones
{
    public class BodegasPresentacion: IBodegasPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Bodegas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Bodegas/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Bodegas>();

            return JsonConvert.DeserializeObject<List<Bodegas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Bodegas Guardar(Bodegas entidad)
        {
            if (entidad.Id_Bodega != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Bodegas/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Bodegas();

            return JsonConvert.DeserializeObject<Bodegas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Bodegas Modificar(Bodegas entidad)
        {
            if (entidad.Id_Bodega == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Bodegas/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Bodegas();

            return JsonConvert.DeserializeObject<Bodegas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Bodegas Eliminar(Bodegas entidad)
        {
            if (entidad.Id_Bodega == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Bodegas/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Bodegas();

            return JsonConvert.DeserializeObject<Bodegas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
