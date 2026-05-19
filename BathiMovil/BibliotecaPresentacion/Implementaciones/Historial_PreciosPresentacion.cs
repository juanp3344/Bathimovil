using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class Historial_PreciosPresentacion: IHistorial_PreciosPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Historial_Precios> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Historial_Precios/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Historial_Precios>();

            return JsonConvert.DeserializeObject<List<Historial_Precios>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Historial_Precios Guardar(Historial_Precios entidad)
        {
            if (entidad.Id_Historial != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Historial_Precios/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Historial_Precios();

            return JsonConvert.DeserializeObject<Historial_Precios>(
                respuesta["Valor"].ToString()!)!;
        }

        public Historial_Precios Modificar(Historial_Precios entidad)
        {
            if (entidad.Id_Historial == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Historial_Precios/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Historial_Precios();

            return JsonConvert.DeserializeObject<Historial_Precios>(
                respuesta["Valor"].ToString()!)!;
        }

        public Historial_Precios Eliminar(Historial_Precios entidad)
        {
            if (entidad.Id_Historial == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Historial_Precios/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Historial_Precios();

            return JsonConvert.DeserializeObject<Historial_Precios>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
