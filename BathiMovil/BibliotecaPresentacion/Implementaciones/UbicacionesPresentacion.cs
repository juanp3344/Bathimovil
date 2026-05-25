using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class UbicacionesPresentacion : IUbicacionesPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Ubicaciones> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Ubicaciones/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Ubicaciones>();

            return JsonConvert.DeserializeObject<List<Ubicaciones>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Ubicaciones Guardar(Ubicaciones entidad)
        {
            if (entidad.Id_Ubicacion != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Ubicaciones/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Ubicaciones();

            return JsonConvert.DeserializeObject<Ubicaciones>(
                respuesta["Valor"].ToString()!)!;
        }

        public Ubicaciones Modificar(Ubicaciones entidad)
        {
            if (entidad.Id_Ubicacion == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Ubicaciones/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Ubicaciones();

            return JsonConvert.DeserializeObject<Ubicaciones>(
                respuesta["Valor"].ToString()!)!;
        }

        public Ubicaciones Eliminar(Ubicaciones entidad)
        {
            if (entidad.Id_Ubicacion == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Ubicaciones/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Ubicaciones();

            return JsonConvert.DeserializeObject<Ubicaciones>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
